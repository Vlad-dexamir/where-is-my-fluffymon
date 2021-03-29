using System;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonApi
{
    public class Person
    {
        public static readonly Regex PersonEmailPattern = new(
            @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
        );

        public static Person Create(CreatePersonRequest createPersonRequest)
        {
            return new(createPersonRequest);
        }

        public const int NameMinLength = 3;
        public const int NameMaxLength = 32;
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 32;

#nullable disable
        [BsonId] [BsonRepresentation(BsonType.String)]
        public readonly string Id;

        [BsonElement("personId")] public readonly string PersonId;

        [BsonElement("firstName")] public readonly string FirstName;

        [BsonElement("lastName")] public readonly string LastName;

        [BsonElement("email")] public readonly string Email;

        [BsonElement("password")] public readonly string Password;

        [BsonElement("location")] public readonly PersonLocation Location;

        [BsonElement("isAdmin")] public readonly bool IsAdmin;
#nullable enable
        [BsonElement("phoneNumber")] public readonly string? PhoneNumber;

        [BsonElement("profilePicture")] public readonly string? ProfilePicture;

        private Person(CreatePersonRequest payload)
        {
            Id = Guid.NewGuid().ToString();

            PersonId = Id;

            FirstName = payload.FirstName;

            LastName = payload.LastName;

            Email = payload.Email;

            Password = payload.Password;

            Location = payload.Location;

            if (!string.IsNullOrEmpty(payload.PhoneNumber)) PhoneNumber = payload.PhoneNumber;

            if (!string.IsNullOrEmpty(payload.ProfilePicture)) ProfilePicture = payload.ProfilePicture;

            IsAdmin = false;
        }
    }
}
