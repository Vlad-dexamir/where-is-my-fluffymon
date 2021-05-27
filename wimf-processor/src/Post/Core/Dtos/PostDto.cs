using System.Collections.Generic;
using Utils;

namespace PostApi
{
    public class PostDto
    {
#nullable disable
        public string PostId { get; set; }
        public string PostType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Location Location { get; set; }
        public string UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public IEnumerable<string> Attachements { get; set; }
        public long CreatedAt { get; set; }
        
#nullable enable
        public long? UpdatedAt { get; set; }
        
        public int? Reward { get; set; }
    }
}