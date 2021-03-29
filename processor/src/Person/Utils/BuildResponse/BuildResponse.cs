using System.Net;

namespace Person.Utils.BuildResponse
{
    public static class BuildResponse
    {
        public static Response Success(object? body)
        {
            return Response.Create((int) HttpStatusCode.OK, body);
        }

        public static Response Failure(int statusCode, object? body)
        {
            return Response.Create(statusCode, body);
        }
    }
}