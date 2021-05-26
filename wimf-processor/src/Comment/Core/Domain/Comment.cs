using MongoDB.Bson.Serialization.Attributes;
using Utils;

namespace CommentApi
{
    public class Comment: BaseEntity
    {
        public const int MinLength = 2;
        public const int MaxLength = 300;

#nullable disable
        [BsonElement("commentId")] public string CommentId { get; set; }
        [BsonElement("postId")] public string PostId { get; set; }
        [BsonElement("userId")] public string UserId { get; set; }
        [BsonElement("createdAt")] public long CreatedAt { get; set; }
        [BsonElement("text")] public string Text { get; set; }
#nullable enable
        [BsonElement("userInfo")] public UserInfo? UserInfo { get; set; }
        [BsonElement("parentId")] public string? ParentId { get; set; }

        [BsonElement("updatedAt")] public long? UpdatedAt { get; set; }
    }
}