using System.Collections.Generic;
#nullable disable
namespace PostApi
{
    public class SearchPostResponse
    {
        public long Total { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}