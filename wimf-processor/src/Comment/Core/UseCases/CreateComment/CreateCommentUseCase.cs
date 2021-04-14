using System;
using System.Threading.Tasks;
using Post.Utils.Jwt;

namespace PostApi
{
    public static class CreateCommentUseCase
    {
        public static readonly Func<CreatePostDeps, CreateCommentRequest, Task<string>> Execute =
            async (createPostDeps, createCommentRequest) =>
            {
                var postRepository = createPostDeps.PostRepository;

                var foundPost = await postRepository.GetPostById(createPostRequest.Id);

                if (foundPost == null) throw new PostException(PostExceptionType.PostDoesntExists);

                var commentToCreate = new Comment
                {
                    Comment = createCommentRequest.Comment
                };

                var createdComment = await postRepository.AddComment(commentToCreate);

                return new Jwt().Encode(createdComment.Comment);
                //De intrebat pe Vlad
            };
    }
}
