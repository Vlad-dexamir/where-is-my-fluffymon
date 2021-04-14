using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Post.Utils.BuildResponse
{
    public static class BuildResponse
    {
        
        public static object Success(object? body)
        {
            return body != null ? new OkObjectResult(body) : new OkResult();
        }

        public static object Failure(HttpStatusCode statusCode, object? body)
        {
            return new ObjectResult(body) {StatusCode = (int) statusCode};
        }
        
    }
}