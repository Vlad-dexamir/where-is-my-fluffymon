using System.Collections.Generic;

namespace PostApi
{
    public class SearchPostResponse
    {
        public int Total { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}