namespace PersonApi
{
    public class Error
    {
        public PersonExceptionType? Type { get; set; }
        
#nullable disable
        
        public string Message { get; set; }
    }
}