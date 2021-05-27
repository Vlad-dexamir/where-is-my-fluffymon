using System;
using System.Threading.Tasks;
using static System.DateTimeOffset;


namespace PostApi
{
    public static class CreatePostUseCase
    {
        public static readonly Func<CreatePostDeps, CreatePostRequest, Task<PostDto>> Execute =
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
                    CreatedAt = UtcNow.ToUnixTimeSeconds(),
                    Reward = createPostRequest.Reward
                };

                var createdPost = await postRepository.CreatePost(postToCreate);

                return new PostDto
                {
                    PostId = createdPost.PostId,
                    PostType = createdPost.PostType,
                    Title = createdPost.Title,
                    Content = createdPost.Content,
                    Location = createdPost.Location,
                    UserId = createdPost.UserId,
                    UserInfo = createdPost.UserInfo,
                    Attachements = createdPost.Attachements,
                    CreatedAt = createdPost.CreatedAt,
                    Reward = createdPost.Reward
                };
            };
    }
}