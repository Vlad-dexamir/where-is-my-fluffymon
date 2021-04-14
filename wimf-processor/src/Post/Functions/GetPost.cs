using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Post.Utils.BuildResponse;
using PostApi;

namespace Post.Functions
{
    public class GetPost
    {
        private readonly IPostRepository _postRepository;

        public GetPost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("GetPost")]
        public async Task<object> GetPostHandler(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "post/{postId}")]
            HttpRequest req, ILogger log, string postId)
        {
            try
            {
                log.LogInformation("[GET_POST_HANDLER] Retrieving post...");

                GetPostDeps getPostDeps = new GetPostDeps
                {
                    PostRepository = _postRepository
                };

                var post = await GetPostUseCase.Execute(getPostDeps, postId);

                log.LogInformation(
                    $"[GET_POST_HANDLER] Post with postId:${postId} retrieved successfully");

                return BuildResponse.Success(post);
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