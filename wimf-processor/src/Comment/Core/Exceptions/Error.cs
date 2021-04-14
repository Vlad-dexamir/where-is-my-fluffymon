namespace CommentApi
{
    public class Error
    {
#nullable disable
        public readonly string Message;

#nullable enable
        public readonly string Type;

        public Error(string message, string type = CommentExceptionType.CommentError)
        {
            Message = message;
            Type = type;
        }
    }
}
