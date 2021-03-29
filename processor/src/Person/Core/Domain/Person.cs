using System;
using System.Collections.Generic;
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

        public static readonly Dictionary<string, int> PersonConstraints = new()
        {
            {"NAME_MIN", 3},
            {"NAME_MAX", 20},
            {"PASSWORD_MIN", 8},
            {"PASSWORD_MAX", 32},
            {"PHONE_NUMBER_LENGTH", 10}
        };

        public static Person Create(CreatePersonRequest createPersonRequest)
        {
            return new(createPersonRequest);
        }

#nullable disable
        [BsonElement("email")] public readonly string Email;

        [BsonElement("firstName")] public readonly string FirstName;

        [BsonId] [BsonRepresentation(BsonType.String)]
        public readonly string Id;

        [BsonElement("isAdmin")] public readonly bool IsAdmin;

        [BsonElement("lastName")] public readonly string LastName;

        [BsonElement("location")] public readonly PersonLocation Location;

        [BsonElement("password")] public readonly string Password;

#nullable enable

        [BsonElement("phoneNumber")] public readonly string? PhoneNumber;

        [BsonElement("profilePicture")] public readonly string? ProfilePicture;

        private Person(CreatePersonRequest payload)
        {
            Id = Guid.NewGuid().ToString();

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