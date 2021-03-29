using Microsoft.AspNetCore.Http;
using PersonApi;

namespace Person.Utils
{
    public static class Utils
    {
        public static string GetAuthorizationToken(HttpRequest request)
        {
            if (!request.Headers.Keys.Contains("Authorization"))
                throw new PersonException(PersonExceptionType.AuthorizationHeaderIsRequired);

            string authorizationHeader = request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
                throw new PersonException(PersonExceptionType.AuthorizationHeaderIsRequired);

            if (!authorizationHeader.StartsWith("Bearer"))
                throw new PersonException(PersonExceptionType.AuthorizationHeaderMissingBearer);

            return authorizationHeader.Substring(6);
        }
    }
}