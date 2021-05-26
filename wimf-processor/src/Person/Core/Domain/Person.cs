using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;
using Utils;

namespace PersonApi
{
    public class Person: BaseEntity 
    {
        public static readonly Regex PersonEmailPattern = new(
            @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
        );

        public const int NameMinLength = 3;
        public const int NameMaxLength = 32;
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 32;

#nullable disable
        [BsonElement("personId")] public string PersonId { get; set; }

        [BsonElement("firstName")] public string FirstName { get; set; }

        [BsonElement("lastName")] public string LastName { get; set; }

        [BsonElement("email")] public string Email { get; set; }

        [BsonElement("password")] public string Password { get; set; }

        [BsonElement("location")] public PersonLocation Location { get; set; }

        [BsonElement("isAdmin")] public bool IsAdmin { get; set; } = false;
#nullable enable
        [BsonElement("phoneNumber")] public string? PhoneNumber { get; set; }

        [BsonElement("profilePicture")] public string? ProfilePicture { get; set; }
    }
}