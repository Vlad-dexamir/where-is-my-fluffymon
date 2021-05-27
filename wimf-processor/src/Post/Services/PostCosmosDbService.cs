using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;
using Utils;

namespace PostApi
{
    public class PostCosmosDbService : IPostRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostCosmosDbService()
        {
            var connectionString = Environment.GetEnvironmentVariable("COSMOS_DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the COSMOS_DB_CONNECTION_STRING"
                );

            var databaseName = Environment.GetEnvironmentVariable("POST_DATABASE_NAME");
            if (string.IsNullOrEmpty(databaseName))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the POST_DATABASE_NAME"
                );

            var collectionName = Environment.GetEnvironmentVariable("POST_COLLECTION_NAME");
            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the POST_COLLECTION_NAME"
                );

            var config = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            config.SslSettings =
                new SslSettings {EnabledSslProtocols = SslProtocols.Tls12};

            var mongoClient = new MongoClient(config);

            var database = mongoClient.GetDatabase(databaseName);

            _posts = database.GetCollection<Post>(collectionName);
        }

        public async Task<Post> CreatePost(Post post)
        {
            await _posts.InsertOneAsync(post);

            return post;
        }

        public async Task<Post> GetPost(string postId)
        {
            var foundPost = await _posts.FindAsync(post => post.PostId == postId);

            return foundPost.FirstOrDefault();
        }

        public async Task<SearchPostResponse> SearchPost(SearchPostRequest searchPostRequest)
        {
            bool isAnyFilter = searchPostRequest.Filters.Query != null
                               || searchPostRequest.Filters.PostType != null
                               || searchPostRequest.Filters.UserId != null
                               || searchPostRequest.Filters.Location != null;

            var filters = isAnyFilter
                ? Builders<Post>.Filter.Or(
                    PostFilters.CreateFilterByQuery(searchPostRequest.Filters.Query ?? string.Empty),
                    PostFilters.CreateFilterByPostType(searchPostRequest.Filters.PostType ?? string.Empty),
                    PostFilters.CreateFilterByUserId(searchPostRequest.Filters.UserId ?? string.Empty),
                    PostFilters.CreateFilterByLocation(searchPostRequest.Filters.Location ?? new Location())
                )
                : FilterDefinition<Post>.Empty;

            var searchResult = _posts.Find(filters);

            var totalResults = await searchResult.CountDocumentsAsync();
            var posts = await searchResult
                .Skip(searchPostRequest.From)
                .Limit(searchPostRequest.Size)
                .ToListAsync();

            return new SearchPostResponse
            {
                Total = totalResults,
                Posts = posts,
            };
        }

        public async Task UpdatePost(string postId, Post updatedPost)
        {
            await _posts.ReplaceOneAsync(
                post => post.PostId == postId,
                updatedPost,
                new ReplaceOptions {IsUpsert = true}
            );
        }

        public async Task DeletePost(string postId)
        {
            await _posts.DeleteOneAsync(post => post.PostId == postId);
        }
    }
}