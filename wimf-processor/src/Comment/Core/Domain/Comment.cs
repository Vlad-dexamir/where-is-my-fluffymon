using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostApi
{
    public class Comment
    {

        public const int NameMinLength = 2;
        public const int NameMaxLength = 280;

    }
}