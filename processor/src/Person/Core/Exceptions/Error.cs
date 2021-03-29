namespace PersonApi
{
    public class Error
    {
        public static Error Create(string message, string type = PersonExceptionType.PersonError)
        {
            return new(message, type);
        }

#nullable disable
        public readonly string Message;

#nullable enable
        public readonly string Type;

        private Error(string message, string type)
        {
            Message = message;
            Type = type;
        }
    }
}
