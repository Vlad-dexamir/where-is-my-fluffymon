namespace PersonApi
{
    public class Error
    {
#nullable disable
        public readonly string Message;

#nullable enable
        public readonly string Type;

        public Error(string message, string type = PersonExceptionType.PersonError)
        {
            Message = message;
            Type = type;
        }
    }
}