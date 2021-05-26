using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;

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
            var searchResult = await _posts.FindAsync(post =>
                post.Title.Contains(searchPostRequest.Query)
                || post.PostId.Contains(searchPostRequest.Query)
                || post.PostType.Equals(searchPostRequest.PostType)
                || post.UserId.Equals(searchPostRequest.UserId)
            );

            return new SearchPostResponse
            {
                Total = searchResult.Current.Count(),
                Posts = searchResult.Current
                    .ToList()
                    .GetRange(searchPostRequest.From, searchPostRequest.Size)
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