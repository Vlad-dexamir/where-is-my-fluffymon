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

            _jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? string.Empty;

            if (string.IsNullOrEmpty(_jwtKey)) throw new Exception("Please provide JWT_KEY");
        }

        public string Encode(string userId)
        {
            var now = DateTime.Now;
            var expirationTime = now.AddHours(1).Ticks;

            var payload = JwtPayload.Create(userId, expirationTime);

            return _jwtEncoder.Encode(payload, _jwtKey);
        }

        public JwtPayload Decode(string jwtToken)
        {
            var payload = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_jwtKey)
                .MustVerifySignature()
                .Decode<JwtPayload>(jwtToken);

            if (string.IsNullOrEmpty(payload.UserId) || payload.ExpirationTime < DateTime.Now.Ticks)
                throw new PersonException(PersonExceptionType.PersonJwtIsInvalid);

            return payload;
        }
    }
}