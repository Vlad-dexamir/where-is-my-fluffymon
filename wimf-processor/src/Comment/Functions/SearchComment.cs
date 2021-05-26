using System;
using System.Net;
using System.Threading.Tasks;
using CommentApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Utils;

namespace Comment.Functions

{
    public class SearchComment
    {
        private readonly ICommentRepository _commentRepository;

        public SearchComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [FunctionName("SearchComment")]
        public async Task<object> SearchCommentHandler(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "search-comment-by-post/{postId}")]
            HttpRequest req, ILogger log, string postId)
        {
            try
            {
                log.LogInformation("[SEARCH_COMMENT_HANDLER] searching for comments..");

                var searchCommentDeps = new SearchCommentDeps
                {
                    CommentRepository = _commentRepository
                };

                var from = int.Parse(req.Query["from"]);
                var size = int.Parse(req.Query["size"]);

                var searchCommentResponse = await SearchCommentUseCase.Execute(searchCommentDeps, from, size, postId);

                return BuildResponse.Success(searchCommentResponse);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);
                
                if (exception.Message
                    .Equals(CommentException.Exceptions[CommentExceptionType.CommentsDoNotExist])
                )

                    return BuildResponse.Failure(HttpStatusCode.BadRequest, new Error(
                        exception.Message,
                        CommentExceptionType.CommentsDoNotExist
                    ));


                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(
                    exception.Message
                ));
            }
        }
    }
}