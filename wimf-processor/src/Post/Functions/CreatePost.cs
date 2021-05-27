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
    public class CreatePost
    {
        private readonly IPostRepository _postRepository;

        public CreatePost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("CreatePost")]
        public async Task<object> CreatePostHandler(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "post")] 
            HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("[CREATE_POST_HANDLER] Retrieving createPostRequest...");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createPostRequest = JsonConvert.DeserializeObject<CreatePostRequest>(requestBody);
              
                log.LogInformation("[CREATE_POST_HANDLER] Validating createPostRequest...");

                var validationResult = await new CreatePostRequestValidator().ValidateAsync(createPostRequest);

                if (!validationResult.IsValid)


                log.LogInformation("[CREATE_POST_HANDLER] Creating post...");

                CreatePostDeps createPostDeps = new CreatePostDeps
                {
                    PostRepository = _postRepository
                };

                var createdPost = await CreatePostUseCase.Execute(createPostDeps, createPostRequest);
                
                log.LogInformation("[CREATE_POST_HANDLER] Post created successfully");

                return BuildResponse.Success(createdPost);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);

                if (exception.Message
                    .Equals(PostException.Exceptions[PostExceptionType.PostAlreadyExists])
                )

                    return BuildResponse.Failure(HttpStatusCode.BadRequest, new Error(
                        exception.Message,
                        PostExceptionType.PostAlreadyExists
                    ));

                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(
                    exception.Message
                ));
            }
        }
    }
}