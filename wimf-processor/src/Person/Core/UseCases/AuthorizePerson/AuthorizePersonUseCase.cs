using System;
using System.Threading.Tasks;
using Person.Utils.Jwt;

namespace PersonApi
{
    public static class AuthorizePersonUseCase
    {
        public static readonly Func<AuthorizePersonDeps, AuthorizePersonRequest, Task<string>> Execute =
            async (authorizePersonDeps, authorizePersonRequest) =>
            {
                var personRepository = authorizePersonDeps.PersonRepository;

                var foundPerson = await personRepository.GetPersonByEmail(authorizePersonRequest.Email);

                if (foundPerson == null) throw new PersonException(PersonExceptionType.PersonDoesNotExist);

                var isPasswordValid = BCrypt.Net.BCrypt
                    .Verify(authorizePersonRequest.Password, foundPerson.Password);

                if (!isPasswordValid) throw new PersonException(PersonExceptionType.PersonInvalidCredentials);

                return new Jwt().Encode(foundPerson.PersonId);
            };
    }
}