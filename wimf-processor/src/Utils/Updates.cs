namespace Utils
{
    public static class UpdateActionType
    {
        public const string Put = "Put";
        public const string Delete = "Delete";
    }

  #nullable  enable
    public class UpdateAction<T>
    {
        public T? Value { get; set; }
        public string? Action { get; set; }
    }
}