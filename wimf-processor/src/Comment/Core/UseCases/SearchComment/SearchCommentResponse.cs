using System.Collections.Generic;

namespace CommentApi
{
    public class SearchCommentResponse
    {
        public int Total { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}