using System;
using System.Threading.Tasks;
using Person.Utils.Jwt;

namespace PersonApi
{
    public static class CreatePersonUseCase
    {
        public static readonly Func<IPersonRepository, CreatePersonRequest, Task<string>> Execute =
            async (personRepository, createPersonRequest) =>
            {
                var foundUser = await personRepository.GetPersonByEmail(createPersonRequest.Email);

                if (foundUser != null) throw new PersonException(PersonExceptionType.PersonAlreadyExists);

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createPersonRequest.Password);

                var personId = Guid.NewGuid().ToString();

                var personToCreate = new Person
                {
                    Id = personId,
                    PersonId = personId,
                    FirstName = createPersonRequest.FirstName,
                    LastName = createPersonRequest.LastName,
                    Email = createPersonRequest.Email,
                    Password = hashedPassword,
                    PhoneNumber = createPersonRequest.PhoneNumber,
                    Location = createPersonRequest.Location,
                    ProfilePicture = createPersonRequest.ProfilePicture
                };

                var createdPerson = await personRepository.CreatePerson(personToCreate);

                return new Jwt().Encode(createdPerson.PersonId);
            };
    }
}
