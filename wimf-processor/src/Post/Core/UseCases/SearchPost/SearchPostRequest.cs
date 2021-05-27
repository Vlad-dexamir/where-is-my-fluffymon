using Utils;

namespace PostApi
{
    public class SearchPostRequest
    {
        public const int FromMinValue = 0;
        public const int SizeMaxValue = 500;

        public static SearchPostRequest Create(
            PostFilters filters,
            int from = FromMinValue,
            int size = SizeMaxValue
        )
        {
            if (from < FromMinValue)
            {
                throw new PostException(PostExceptionType.SearchPostRequestInvalid);
            }

            if (size > SizeMaxValue)
            {
                throw new PostException(PostExceptionType.SearchPostRequestInvalid);
            }
            
            return new SearchPostRequest(filters, from, size);
        }

        public readonly int From;

        public readonly int Size;

        public readonly PostFilters Filters;

        private SearchPostRequest(
            PostFilters filters,
            int from,
            int size
        )
        {
            From = from;

            Size = size;

            Filters = filters;
        }
    }
}