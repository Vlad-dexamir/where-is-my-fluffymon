using System;
using System.Threading.Tasks;
using static System.DateTimeOffset;


namespace PostApi
{
    public class CreatePostUseCase
    {
        
        public static readonly Func<CreatePostDeps, CreatePostRequest, Task<Post>> Execute =
            async (createPostDeps, createPostRequest) =>
            {
                var postRepository = createPostDeps.PostRepository;
                
                var postId = Guid.NewGuid().ToString();
                
                var postToCreate = new Post
                {
                    Id = postId,
                    PostId = postId,
                    PostType = createPostRequest.PostType,
                    Title = createPostRequest.Title,
                    Content = createPostRequest.Content,
                    Location = createPostRequest.Location,
                    UserId = createPostRequest.UserId,
                    UserInfo = createPostRequest.UserInfo,
                    Attachements = createPostRequest.Attachements,
                    CreatedAt = UtcNow.ToUnixTimeSeconds()
                    
                };

                var createdPost = await postRepository.CreatePost(postToCreate);

                return createdPost;
            };
        
    }
}