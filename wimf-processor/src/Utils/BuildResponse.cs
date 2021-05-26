using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Utils
{
    #nullable enable
    public static class BuildResponse
    {
        public static object Success(object? body)
        {
            return body != null ? (object) new OkObjectResult(body) : new OkResult();
        }

        public static object Failure(HttpStatusCode statusCode, object? body)
        {
            return new ObjectResult(body) {StatusCode = (int) statusCode};
        }
    }
}