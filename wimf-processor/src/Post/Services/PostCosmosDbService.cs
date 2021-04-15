using System;
using System.Collections.Generic;
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

        public Task<Post> GetPostByType(string postType)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostByUser(string userId)
        {
            var foundPost = await _posts.FindAsync(post => post.UserId == userId);

            return foundPost.FirstOrDefault();
        }

        public Task<Post> UpdatePost(string id, Post updatedPost)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }


        public Task DeletePost(string postId)
        {
            throw new NotImplementedException();
        }
    }
}