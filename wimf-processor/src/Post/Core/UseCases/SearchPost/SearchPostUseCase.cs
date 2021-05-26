using System;
using System.Threading.Tasks;

namespace PostApi
{
    public static class SearchPostUseCase
    {
        public static readonly Func<SearchPostDeps, int, int, PostFilters, Task<SearchPostResponse>> Execute =
            async (searchPostDeps, from, size, filters) =>
            {
                var searchRequest = SearchPostRequest.Create(filters, from, size);

                var postRepository = searchPostDeps.PostRepository;

                return await postRepository.SearchPost(searchRequest);
            };
    }
}