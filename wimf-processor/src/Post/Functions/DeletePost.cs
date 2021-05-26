using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PostApi;
using Utils;

namespace Post.Functions
{
    public class DeletePost
    {
        private readonly IPostRepository _postRepository;

        public DeletePost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("DeletePost")]
        public async Task<object> DeletePostHandler(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "post/{postId}")]
            HttpRequest req, ILogger log, string postId)
        {
            try
            {
                log.LogInformation("[DELETE_POST_HANDLER] Deleting post...");

                DeletePostDeps deletePostDeps = new DeletePostDeps
                {
                    PostRepository = _postRepository
                };

                await DeletePostUseCase.Execute(deletePostDeps, postId);

                log.LogInformation(
                    $"[DELETE_POST_HANDLER] Post with postId:${postId} deleted successfully");

                return BuildResponse.Success(null);
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