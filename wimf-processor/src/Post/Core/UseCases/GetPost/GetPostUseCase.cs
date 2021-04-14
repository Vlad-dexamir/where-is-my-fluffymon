using System;
using System.Threading.Tasks;

namespace PostApi
{
    public static class GetPostUseCase
    {
        public static readonly Func<GetPostDeps, string, Task<PostDto>> Execute =
            async (getPersonDeps, personId) =>
            {
                var personRepository = getPersonDeps.PostRepository;

                var foundPost = await personRepository.GetPost(personId);

                if (foundPost == null)
                {
                    throw new PostException(PostExceptionType.PostDoesNotExist);
                }

                return new PostDto
                {
                    PostId = foundPost.PostId,
                    Title = foundPost.Title,
                    Content = foundPost.Content,
                    PostType = foundPost.PostType,
                    UserId = foundPost.UserId,
                    UserInfo = foundPost.UserInfo,
                    Location = foundPost.Location,
                    Attachements = foundPost.Attachements,
                    CreatedAt = foundPost.CreatedAt,
                    UpdatedAt = foundPost.UpdatedAt
                };
            };
    }
}