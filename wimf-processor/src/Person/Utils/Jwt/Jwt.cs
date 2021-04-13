using System;
using static System.DateTimeOffset;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using PersonApi;

namespace Person.Utils.Jwt
{
    public class Jwt : IJwt
    {
        private readonly IJwtEncoder _jwtEncoder;
        private readonly IJwtDecoder _jwtDecoder;
        private readonly string _jwtKey;

        public Jwt()
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder base64Encoder = new JwtBase64UrlEncoder();
            var dateTimeProvider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, dateTimeProvider);

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            if (string.IsNullOrEmpty(jwtKey))
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply the JWT_KEY"
                );

            _jwtEncoder = new JwtEncoder(algorithm, serializer, base64Encoder);
            _jwtDecoder = new JwtDecoder(serializer, validator, base64Encoder, algorithm);
            _jwtKey = jwtKey;
        }

        public string Encode(string userId)
        {
            var payload = new JwtPayload(userId).Create();

            return _jwtEncoder.Encode(payload, _jwtKey);
        }

        public JwtPayload Decode(string authorizationHeader)
        {
            try
            {
                var payload = _jwtDecoder
                    .DecodeToObject<JwtPayload>(authorizationHeader, _jwtKey, verify: true);

                if (string.IsNullOrEmpty(payload.UserId) || payload.Exp < UtcNow.ToUnixTimeSeconds())
                    throw new PersonException(PersonExceptionType.PersonJwtIsInvalid);

                return payload;
            }
            catch (TokenExpiredException)
            {
                throw new TokenExpiredException("Token has expired");
            }

            catch (SignatureVerificationException)
            {
                throw new SignatureVerificationException("Token has invalid signature");
            }
        }
    }
}