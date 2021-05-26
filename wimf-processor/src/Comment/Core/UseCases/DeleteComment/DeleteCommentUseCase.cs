using System;
using System.Threading.Tasks;

namespace CommentApi
{
    public static class DeleteCommentUseCase
    {
        public static Func<DeleteCommentDeps, string, Task> Execute =
            async (deleteCommentDeps, commentId) =>
            {
                var commentRepository = deleteCommentDeps.CommentRepository;

                var foundComment = await commentRepository.GetComment(commentId);

                if (foundComment == null) throw new CommentException(CommentExceptionType.CommentsDoNotExist);

                await commentRepository.DeleteComment(commentId);
            };
    }
}