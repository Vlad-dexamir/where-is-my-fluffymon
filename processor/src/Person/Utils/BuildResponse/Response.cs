using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Person.Utils.BuildResponse
{
    public class Response
    {
        public readonly object? Body;
        public readonly Dictionary<string, string> Headers;
        public readonly int StatusCode;

        private Response(int statusCode, object? body)
        {
            Headers = new Dictionary<string, string>
            {
                {"Access-Control-Allow-Credentials", "true"},
                {"Access-Control-Allow-Origin", "*"}
            };

            StatusCode = statusCode;

            if (body != null) Body = new ObjectResult(body);
        }

        public static Response Create(int statusCode, object? body)
        {
            return new(statusCode, body);
        }
    }
}