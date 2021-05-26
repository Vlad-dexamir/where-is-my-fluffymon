using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Utils
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public virtual string Id { get; set; }
    }
}