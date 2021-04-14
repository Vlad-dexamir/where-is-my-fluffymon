using System.Collections;
using System.Collections.Generic;

namespace CommentApi
{
    public class CommentDto
    {
#nullable disable
        public string CommentId { get; set; }
        public string PostId { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public long CreatedAt { get; set; }

#nullable enable
        public long? UpdatedAt { get; set; }
    }
}