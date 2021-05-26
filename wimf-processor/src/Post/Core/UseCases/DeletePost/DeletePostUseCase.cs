using System;
using System.Threading.Tasks;

namespace PostApi
{
    public static class DeletePostUseCase
    {
        public static readonly Func<DeletePostDeps, string, Task> Execute =
            async (deletePostDeps, postId) =>
            {
                var postRepository = deletePostDeps.PostRepository;

                var foundPost = postRepository.GetPost(postId);

                if (foundPost == null) throw new PostException(PostExceptionType.PostDoesNotExist);

                await postRepository.DeletePost(postId);
            };
    }
}