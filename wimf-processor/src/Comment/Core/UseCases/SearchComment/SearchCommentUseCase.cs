using System;
using System.Threading.Tasks;

namespace CommentApi
{
    public static class SearchCommentUseCase
    {
        public static readonly Func<SearchCommentDeps, int, int, string, Task<SearchCommentResponse>> Execute =
            async (searchCommentDeps, from, size, postId) =>
            {
                var commentRepository = searchCommentDeps.CommentRepository;

                SearchCommentRequest searchCommentRequest = SearchCommentRequest.Create(
                    postId,
                    from,
                    size
                );

                return await commentRepository.SearchComments(searchCommentRequest);
            };
    }
}