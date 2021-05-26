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
    public class SearchPost
    {
        private readonly IPostRepository _postRepository;

        public SearchPost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("SearchPost")]
        public async Task<object> SearchPostHandler(
            [HttpTrigger(AuthorizationLevel.Function, "get",
                Route = "search-post")]
            HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("[SEARCH_POST_HANDLER] Retrieving posts...");

                SearchPostDeps searchPostDeps = new SearchPostDeps
                {
                    PostRepository = _postRepository
                };

                PostFilters filters = new PostFilters
                {
                    UserId = req.Query["userId"],
                    PostType = req.Query["postType"],
                    Query = req.Query["query"]
                };

                var from = int.Parse(req.Query["from"]);

                var size = int.Parse(req.Query["size"]);

                var result = await SearchPostUseCase.Execute(searchPostDeps, from, size, filters);

                return BuildResponse.Success(result);
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