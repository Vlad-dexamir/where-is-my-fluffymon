namespace CommentApi
{
    public static class CommentExceptionType
    {
        public const string TextIsRequired = "TextIsRequired";
        public const string TextIsInvalid = "TextIsInvalid";
        public const string CommentError = "CommentError";
        public const string UserIdIsRequired = "UserIdIsRequired";
        public const string UserInfoIsRequired = "UserInfoIsRequired";
        public const string CreatedAtIsRequired = "CreatedAtIsRequired";
        public const string CommentsDoNotExist = "CommentsDoNotExist";
    }
}
