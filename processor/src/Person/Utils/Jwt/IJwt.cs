namespace Person.Utils.Jwt
{
    public interface IJwt
    {
        public string Encode(string userId);

        public JwtPayload Decode(string authorizationHeader);
    }
}