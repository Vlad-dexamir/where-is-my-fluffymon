using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentApi
{
    public interface ICommentRepository
    {
        public Task<Comment> CreateComment(Comment comment);

        public Task<Comment> GetComment(string commentId);

        public Task<SearchCommentResponse> SearchComments(SearchCommentRequest searchCommentRequest);

        public Task DeleteComment(string commentId);
    }
}