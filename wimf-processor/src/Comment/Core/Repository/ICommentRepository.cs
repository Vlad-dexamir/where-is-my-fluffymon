using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentApi
{
    public interface ICommentRepository
    {
        public Task<Comment> CreateComment(Comment comment);

        public Task<IEnumerable<Comment>> GetAllCommentsByPost(string postId);

        public Task<Comment> UpdateComment(string id, Comment updatedComment);

        public Task DeleteComment(string commentId);
    }
}