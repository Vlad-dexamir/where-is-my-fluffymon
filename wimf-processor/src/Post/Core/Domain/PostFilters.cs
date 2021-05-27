using MongoDB.Driver;
using Utils;

namespace PostApi
{
    public class PostFilters
    {
        public static FilterDefinition<Post> CreateFilterByQuery(string query)
        {
            var queryFilterByTitle = Builders<Post>.Filter.Eq(post => post.Title,query);
            
            var queryFilterByContent = Builders<Post>.Filter.Eq(post => post.Content, query);
            
            var queryFilterByPostId = Builders<Post>.Filter.Eq(post => post.PostId, query);
            
            return Builders<Post>.Filter.And(
                queryFilterByTitle,
                queryFilterByContent,
                queryFilterByPostId
            );
        }

        public static FilterDefinition<Post> CreateFilterByPostType(string postType)
        {
            return Builders<Post>.Filter.Eq(post => post.PostType, postType);
        }

        public static FilterDefinition<Post> CreateFilterByUserId(string userId)
        {
            return Builders<Post>.Filter.Eq(post => post.UserId, userId);
        }

        public static FilterDefinition<Post> CreateFilterByLocation(Location location)
        {
            return Builders<Post>.Filter.Eq(post => post.Location, location);
        }
        
        #nullable enable
        public string? PostType { get; set; }
        public string? UserId { get; set; }
        public string? Query { get; set; }
        public Location? Location { get; set; }
    }
}