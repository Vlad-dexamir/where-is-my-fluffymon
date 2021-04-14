using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostApi
{
    public interface IPostRepository
    {
        public Task<Post> CreatePost(Post post);

        public Task<Post> GetPost(string postId);

        public Task<Post> GetPostByUser(string userId);

        public Task<Post> GetPostByType(string postType);
        
        public Task<IEnumerable<Post>> GetAllPosts();

        public Task<Post> UpdatePost(string id, Post updatedPost);

        public Task DeletePost(string postId);
    }
}