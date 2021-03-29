namespace Person.Utils.Jwt
{
    public class JwtPayload
    {
        public readonly long ExpirationTime;

        public readonly string UserId;

        private JwtPayload(string userId, long expirationTime)
        {
            UserId = userId;

            ExpirationTime = expirationTime;
        }

        public static JwtPayload Create(string userId, long expirationTime)
        {
            return new(userId, expirationTime);
        }
    }
}