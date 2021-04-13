using System.Collections.Generic;
using static System.DateTimeOffset;

namespace Person.Utils.Jwt
{
    public class JwtPayload
    {
#nullable disable

        public Dictionary<string, object> Create()
        {
            return new Dictionary<string, object>
            {
                {"exp", Exp},
                {"userId", UserId}
            };
        }

        public readonly long Exp;
        public readonly string UserId;

        public JwtPayload(string userId)
        {
            UserId = userId;

            Exp = UtcNow.AddHours(1).ToUnixTimeSeconds();
        }
    }
}