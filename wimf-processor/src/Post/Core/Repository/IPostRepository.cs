using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostApi
{
    public interface IPostRepository
    {
        public Task<Post> CreatePost(Post post);

        public Task<Post> GetPost(string postId);

        public Task<SearchPostResponse> SearchPost(SearchPostRequest request);
        public Task UpdatePost(string id, Post updatedPost);

        public Task DeletePost(string postId);
    }
}