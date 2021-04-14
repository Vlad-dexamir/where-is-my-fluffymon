using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PostApi
{
    public class Post
    {
        
        public const int TitleMinLength = 3;
        public const int TitleMaxLength = 40;
        public const int ContentMaxLength = 600;

#nullable disable
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("postId")] public string PostId { get; set; }

        [BsonElement("postType")] public string PostType { get; set; }

        [BsonElement("title")] public string Title { get; set; }

        [BsonElement("content")] public string Content { get; set; }

        [BsonElement("location")] public UserLocation Location { get; set; }

        [BsonElement("userId")] public string UserId { get; set; }
        
        [BsonElement("createdAt")] public long CreatedAt { get; set; }

#nullable enable        
        [BsonElement("userInfo")] public UserInfo? UserInfo { get; set; }
        
        [BsonElement("attachements")] public IEnumerable<string>? Attachements { get; set; }
        
        [BsonElement("updatedAt")] public long? UpdatedAt { get; set; }
        
    }
}