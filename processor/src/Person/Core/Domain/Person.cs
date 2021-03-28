using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PersonApi
{
    public class Person
    {
        public static Person Create(CreatePersonRequest createPersonRequest)
        {
            return new Person(createPersonRequest);
        }

        public static readonly Regex PersonEmailPattern = new Regex(
            @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
        );

        public static readonly Dictionary<string, int> PersonConstraints = new Dictionary<string, int>
        {
            {"NAME_MIN", 3},
            {"NAME_MAX", 20},
            {"PASSWORD_MIN", 8},
            {"PASSWORD_MAX", 32},
            {"PHONE_NUMBER_LENGTH", 10}
        };

        public readonly string Id;

        public readonly string FirstName;

        public readonly string LastName;

        public readonly string Email;

        public readonly string Password;

        public readonly PersonLocation Location;

        public readonly string? PhoneNumber;

        public readonly string? ProfilePicture;

        public readonly bool IsAdmin;

        private Person(CreatePersonRequest payload)
        {
            Id = Guid.NewGuid().ToString();

            FirstName = payload.FirstName;

            LastName = payload.LastName;

            Email = payload.Email;

            Password = payload.Password;

            Location = payload.Location;

            if (!string.IsNullOrEmpty(payload.PhoneNumber))
            {
                PhoneNumber = payload.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(payload.ProfilePicture))
            {
                ProfilePicture = payload.ProfilePicture;
            }

            IsAdmin = false;
        }
    }
}