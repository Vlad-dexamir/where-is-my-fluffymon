namespace PostApi
{
    public class SearchPostRequest
    {
        public const int FromMinValue = 0;
        public const int SizeMaxValue = 100;

        public static SearchPostRequest Create(
            PostFilters filters,
            int from = FromMinValue,
            int size = SizeMaxValue
        )
        {
            return new(filters, from, size);
        }

        public readonly int From;

        public readonly int Size;

#nullable enable
        public readonly string? PostType;

        public readonly string? UserId;

        public readonly string? Query;

        private SearchPostRequest(
            PostFilters filters,
            int from,
            int size
        )
        {
            From = from;

            Size = size;

            PostType = filters.PostType;

            UserId = filters.UserId;

            Query = filters.Query;
        }
    }
}