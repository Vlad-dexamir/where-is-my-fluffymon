﻿namespace PostApi
{
    public static class PostExceptionType
    {
        public const string TitleIsRequired = "TitleIsRequired";
        public const string TitleIsInvalid = "TitleIsInvalid";
        public const string ContentIsRequired = "ContentIsRequired";
        public const string ContentIsInvalid = "ContentIsInvalid";
        public const string PostAlreadyExists = "PostAlreadyExists";
        public const string PostError = "PostError";
        public const string PostTypeIsRequired = "PostTypeIsRequired";
        public const string PostLocationIsRequired = "PostLocationIsRequired";
        public const string UserIdIsRequired = "UserIdIsRequired";
        public const string UserInfoIsRequired = "UserInfoIsRequired";
        public const string AttachmentsIsRequired = "AttachmentsIsRequired";
        public const string CreatedAtIsRequired = "CreatedAtIsRequired";
        public const string PostDoesNotExist = "PostDoesNotExist";
    }
}