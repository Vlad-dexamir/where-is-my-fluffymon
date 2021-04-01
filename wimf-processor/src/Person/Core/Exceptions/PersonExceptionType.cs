namespace PersonApi
{
    public static class PersonExceptionType
    {
        public const string PersonFirstNameIsRequired = "PersonFirstNameIsRequired";
        public const string PersonFirstNameIsInvalid = "PersonFirstNameIsInvalid";
        public const string PersonLastNameIsRequired = "PersonLastNameIsRequired";
        public const string PersonLastNameIsInvalid = "PersonLastNameIsInvalid";
        public const string PersonEmailIsRequired = "PersonEmailIsRequired";
        public const string PersonEmailIsInvalid = "PersonEmailIsInvalid";
        public const string PersonPasswordIsRequired = "PersonPasswordIsRequired";
        public const string PersonPasswordIsInvalid = "PersonPasswordIsInvalid";
        public const string PersonLocationIsRequired = "PersonLocationIsRequired";
        public const string PersonAlreadyExists = "PersonAlreadyExists";
        public const string PersonJwtIsRequired = "PersonJwtIsRequired";
        public const string PersonJwtIsInvalid = "PersonJwtIsInvalid";
        public const string AuthorizationHeaderIsRequired = "AuthorizationHeaderIsRequired";
        public const string AuthorizationHeaderMissingBearer = "AuthorizationHeaderMissingBearer";
        public const string PersonDoesNotExist = "PersonDoesNotExist";
        public const string PersonError = "PersonError";
    }
}
