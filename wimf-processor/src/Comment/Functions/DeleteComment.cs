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
    public class DeleteComment
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [FunctionName("DeleteComment")]
        public async Task<object> DeleteCommentHandler(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "comment/{commentId}")]
            HttpRequest req, ILogger log, string commentId)
        {
            try
            {
                log.LogInformation("[DELETE_COMMENT_HANDLER] Deleting comment...");

                var deleteCommentDeps = new DeleteCommentDeps
                {
                    CommentRepository = _commentRepository
                };

                 await DeleteCommentUseCase.Execute(deleteCommentDeps, commentId);

                 return BuildResponse.Success(null);
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