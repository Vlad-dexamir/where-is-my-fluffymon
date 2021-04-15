namespace CommentApi
{
    public class Error
    {
#nullable disable
        public readonly string Message;
        public readonly string Type;

        public Error(string message, string type = CommentExceptionType.CommentError)
        {
            Message = message;
            Type = type;
        }
    }
}