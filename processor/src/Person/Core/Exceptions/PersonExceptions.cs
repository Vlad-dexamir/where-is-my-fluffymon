using System;
using System.Collections.Generic;

namespace PersonApi
{
    public enum PersonExceptionType
    {
        PersonFirstNameIsRequired,
        PersonFirstNameIsInvalid,
        PersonLastNameIsRequired,
        PersonLastNameIsInvalid,
        PersonEmailIsRequired,
        PersonEmailIsInvalid,
        PersonPasswordIsRequired,
        PersonPasswordIsInvalid,
        PersonLocationIsRequired,
        PersonPhoneNumberIsInvalid
    }

    public class PersonException : Exception
    {
        public static readonly Dictionary<PersonExceptionType, string> PersonExceptions =
            new()
            {
                {PersonExceptionType.PersonFirstNameIsRequired, "firstName is a required field"},
                {
                    PersonExceptionType.PersonFirstNameIsInvalid,
                    $"firstName must have minimum {Person.PersonConstraints["NAME_MIN"].ToString()} and maximum {Person.PersonConstraints["NAME_MAX"].ToString()} characters"
                },

                {PersonExceptionType.PersonLastNameIsRequired, "lastName is a required field"},
                {
                    PersonExceptionType.PersonLastNameIsInvalid,
                    $"lastName must have minimum {Person.PersonConstraints["NAME_MIN"].ToString()} and maximum {Person.PersonConstraints["NAME_MAX"].ToString()} characters"
                },

                {PersonExceptionType.PersonEmailIsRequired, "email is a required field"},
                {PersonExceptionType.PersonEmailIsInvalid, "email is invalid"},

                {PersonExceptionType.PersonPasswordIsRequired, "password is a required field"},
                {
                    PersonExceptionType.PersonPasswordIsInvalid,
                    $"password must have minimum {Person.PersonConstraints["PASSWORD_MIN"].ToString()} and maximum {Person.PersonConstraints["PASSWORD_MAX"].ToString()} characters"
                },

                {PersonExceptionType.PersonLocationIsRequired, "location is a required field"},

                {
                    PersonExceptionType.PersonPhoneNumberIsInvalid,
                    $"phoneNumber must have exactly {Person.PersonConstraints["PHONE_NUMBER_LENGTH"].ToString()} characters"
                }
            };

        public PersonException()
        {
        }

        public PersonException(PersonExceptionType type) : base(string.Format(PersonExceptions[type]))
        {
        }
    }
}