using System;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using PersonApi;

namespace Person.Utils.Jwt
{
    public class Jwt : IJwt
    {
        private readonly IJwtEncoder _jwtEncoder;
        private readonly string _jwtKey;

        public Jwt()
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder base64Encoder = new JwtBase64UrlEncoder();

            _jwtEncoder = new JwtEncoder(algorithm, serializer, base64Encoder);

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            if (string.IsNullOrEmpty(jwtKey))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the JWT_KEY"
                );

            _jwtKey = jwtKey;
        }

        public string Encode(string userId)
        {
            var payload = new JwtPayload(userId);

            return _jwtEncoder.Encode(payload, _jwtKey);
        }

        public JwtPayload Decode(string authorizationHeader)
        {
            var payload = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_jwtKey)
                .MustVerifySignature()
                .Decode<JwtPayload>(authorizationHeader);

            if (string.IsNullOrEmpty(payload.UserId) || payload.ExpirationTime < DateTime.Now.Ticks)
                throw new PersonException(PersonExceptionType.PersonJwtIsInvalid);

            return payload;
        }
    }
}