using System;
using System.Threading.Tasks;
using static System.DateTimeOffset;


namespace CommentApi
{
    public class CreateCommentUseCase
    {
        public static readonly Func<CreateCommentDeps, CreateCommentRequest, Task<Comment>> Execute =
            async (createCommentDeps, createCommentRequest) =>
            {
                var commentRepository = createCommentDeps.CommentRepository;

                var commentId = Guid.NewGuid().ToString();

                var commentToCreate = new Comment
                {
                    Id = commentId,
                    CommentId = commentId,
                    PostId = createCommentRequest.PostId,
                    ParentId = createCommentRequest.ParentId,
                    Text = createCommentRequest.Text,
                    UserId = createCommentRequest.UserId,
                    UserInfo = createCommentRequest.UserInfo,
                    CreatedAt = UtcNow.ToUnixTimeSeconds()
                };

                var createdComment = await commentRepository.CreateComment(commentToCreate);

                return createdComment;
            };
    }
}