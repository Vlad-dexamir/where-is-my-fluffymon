using static System.DateTimeOffset;

namespace Person.Utils.Jwt
{
    public class JwtPayload
    {
        public static JwtPayload Create(string userId)
        {
            return new(userId);
        }

#nullable disable
        public readonly long ExpirationTime;
        public readonly string UserId;

        private JwtPayload(string userId)
        {
            UserId = userId;

            ExpirationTime = Now.AddHours(1).ToUnixTimeSeconds();
        }
    }
}
