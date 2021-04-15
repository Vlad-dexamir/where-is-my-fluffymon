using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CommentApi
{
    public class CommentCosmosDbService : ICommentRepository
    {
        private readonly IMongoCollection<Comment> _comments;

        public CommentCosmosDbService()
        {
            var connectionString = Environment.GetEnvironmentVariable("COSMOS_DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the COSMOS_DB_CONNECTION_STRING"
                );

            var databaseName = Environment.GetEnvironmentVariable("COMMENT_DATABASE_NAME");
            if (string.IsNullOrEmpty(databaseName))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the COMMENT_DATABASE_NAME"
                );

            var collectionName = Environment.GetEnvironmentVariable("COMMENT_COLLECTION_NAME");
            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the COMMENT_COLLECTION_NAME"
                );

            var config = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            config.SslSettings =
                new SslSettings {EnabledSslProtocols = SslProtocols.Tls12};

            var mongoClient = new MongoClient(config);

            var database = mongoClient.GetDatabase(databaseName);

            _comments = database.GetCollection<Comment>(collectionName);
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            await _comments.InsertOneAsync(comment);

            return comment;
        }

        public Task<IEnumerable<Comment>> GetAllCommentsByPost(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> UpdateComment(string id, Comment updatedComment)
        {
            throw new NotImplementedException();
        }


        public Task DeleteComment(string commentId)
        {
            throw new NotImplementedException();
        }
    }
}