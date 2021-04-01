using static System.DateTimeOffset;

namespace Person.Utils.Jwt
{
    public class JwtPayload
    {
#nullable disable
        public readonly long ExpirationTime;
        public readonly string UserId;

        public JwtPayload(string userId)
        {
            UserId = userId;

            ExpirationTime = Now.AddHours(1).ToUnixTimeSeconds();
        }
    }
}