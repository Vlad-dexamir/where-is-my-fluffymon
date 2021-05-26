namespace CommentApi
{
    public class SearchCommentRequest
    {
        public const int FromMinValue = 0;
        public const int SizeMaxValue = 100;

        public static SearchCommentRequest Create(
            string postId,
            int from = FromMinValue,
            int size = SizeMaxValue
        )
        {
            return new(postId, from, size);
        }

        public readonly int From;

        public readonly int Size;

        public readonly string PostId;
        
        private SearchCommentRequest(
            string postId,
            int from,
            int size
        )
        {
            From = from;

            Size = size;

            PostId = postId;
        }
    }
}