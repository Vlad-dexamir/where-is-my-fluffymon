using System;
using System.Threading.Tasks;
using Utils;
using static System.DateTimeOffset;

namespace PostApi
{
    public static class UpdatePostUseCase
    {
        public static readonly Func<UpdatePostDeps, string, UpdatePostRequest, Task<PostDto>> Execute =
            async (updatePostDeps, postId, updatePostRequest) =>
            {
                var postRepository = updatePostDeps.PostRepository;

                var foundPost = await postRepository.GetPost(postId);

                if (foundPost == null) throw new PostException(PostExceptionType.PostDoesNotExist);

                var updatedPost = foundPost;

                var updates = updatePostRequest.Updates;

                if (updates.Title != null)
                    updatedPost.Title = updates.Title.Action == UpdateActionType.Put ? updates.Title.Value : null;

                if (updates.Content != null)
                    updatedPost.Content = updates.Content.Action == UpdateActionType.Put ? updates.Content.Value : null;

                if (updates.Attachements != null)
                    updatedPost.Attachements = updates.Attachements.Action == UpdateActionType.Put
                        ? updates.Attachements.Value
                        : null;

                updatedPost.UpdatedAt = UtcNow.ToUnixTimeSeconds();

                 await postRepository.UpdatePost(postId, updatedPost);

                 return new PostDto
                 {
                     PostId = updatedPost.PostId,
                     PostType = updatedPost.PostType,
                     Title = updatedPost.Title,
                     Content = updatedPost.Content,
                     Location = updatedPost.Location,
                     UserId = updatedPost.UserId,
                     UserInfo = updatedPost.UserInfo,
                     Attachements = updatedPost.Attachements,
                     CreatedAt = updatedPost.CreatedAt,
                     UpdatedAt = updatedPost.CreatedAt
                 };
            };
    }
}