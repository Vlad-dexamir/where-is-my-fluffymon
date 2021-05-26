using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PostApi;
using Utils;

namespace Post.Functions
{
    public class UpdatePost
    {
        private readonly IPostRepository _postRepository;

        public UpdatePost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("UpdatePost")]
        public async Task<object> UpdatePostHandler(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "post/{postId}")]
            HttpRequest req, ILogger log, string postId)
        {
            try
            {
                log.LogInformation("[UPDATE_POST_HANDLER] Retrieving post...");
                
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var updatePostRequest = JsonConvert.DeserializeObject<UpdatePostRequest>(requestBody);
                
                log.LogInformation("[UPDATE_POST_HANDLER] Validating updatePostRequest...");

                var validationResult = await new UpdatePostRequestValidator().ValidateAsync(updatePostRequest);

                if (!validationResult.IsValid)
                    return BuildResponse.Failure(
                        HttpStatusCode.BadRequest,
                        validationResult.Errors.Select(
                            e => new
                            {
                                Field = e.PropertyName,
                                Error = e.ErrorMessage
                            }));

                log.LogInformation("[UPDATE_POST_HANDLER] Updating post...");

                
                UpdatePostDeps updatePostDeps = new UpdatePostDeps
                {
                    PostRepository = _postRepository
                };

                var updatedPost = await UpdatePostUseCase.Execute(updatePostDeps, postId, updatePostRequest);

                log.LogInformation(
                    $"[UPDATE_POST_HANDLER] Post with postId:${postId} updated successfully");

                return BuildResponse.Success(updatedPost);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);

                if (exception.Message
                    .Equals(PostException.Exceptions[PostExceptionType.PostDoesNotExist])
                )

                    return BuildResponse.Failure(HttpStatusCode.BadRequest, new Error(
                        exception.Message,
                        PostExceptionType.PostDoesNotExist
                    ));

                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(
                    exception.Message
                ));
            }
        }
    }
}