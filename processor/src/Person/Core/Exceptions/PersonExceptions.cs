using System;
using System.Collections.Generic;

namespace PersonApi
{
    public class PersonException : Exception
    {
        public static readonly Dictionary<string, string> Exceptions =
            new()
            {
                {PersonExceptionType.PersonFirstNameIsRequired, "firstName is a required field"},
                {
                    PersonExceptionType.PersonFirstNameIsInvalid,
                    $"firstName must have minimum {Person.NameMinLength.ToString()} " +
                    $"and maximum {Person.NameMaxLength.ToString()} characters"
                },

                {PersonExceptionType.PersonLastNameIsRequired, "lastName is a required field"},
                {
                    PersonExceptionType.PersonLastNameIsInvalid,
                    $"lastName must have minimum {Person.NameMinLength.ToString()} " +
                    $"and maximum {Person.NameMaxLength.ToString()} characters"
                },

                {PersonExceptionType.PersonEmailIsRequired, "email is a required field"},
                {PersonExceptionType.PersonEmailIsInvalid, "email is invalid"},

                {PersonExceptionType.PersonPasswordIsRequired, "password is a required field"},
                {
                    PersonExceptionType.PersonPasswordIsInvalid,
                    $"password must have minimum {Person.PasswordMinLength.ToString()} " +
                    $"and maximum {Person.PasswordMaxLength.ToString()} characters"
                },

                {PersonExceptionType.PersonLocationIsRequired, "location is a required field"},

                {PersonExceptionType.PersonAlreadyExists, "User already exists"},
                {PersonExceptionType.PersonDoesNotExist, "User does not exists"},

                {PersonExceptionType.PersonJwtIsRequired, "Request Headers does not contain Authorization"},
                {PersonExceptionType.PersonJwtIsInvalid, "JWT has expired or stores an invalid value"},

                {PersonExceptionType.AuthorizationHeaderIsRequired, "Authorization Header is required"},
                {PersonExceptionType.AuthorizationHeaderMissingBearer, "Missing Bearer from Authorization Token"},
            };
        
        public PersonException(string type) : base(string.Format(Exceptions[type]))
        {
        }
    }
}
