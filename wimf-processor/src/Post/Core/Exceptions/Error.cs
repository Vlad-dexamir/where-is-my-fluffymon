namespace PostApi
{
public class Error
{
#nullable disable
    public readonly string Message;

#nullable enable
    public readonly string Type;

    public Error(string message, string type = PostExceptionType.PostError)
    {
        Message = message;
        Type = type;
    }
}
}