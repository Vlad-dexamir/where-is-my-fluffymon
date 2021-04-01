using System;
using System.Threading.Tasks;

namespace PersonApi
{
    public static class GetPersonUseCase
    {
        public static readonly Func<GetPersonDeps, string, Task<PersonDto>> Execute =
            async (getPersonDeps, personId) =>
            {
                var personRepository = getPersonDeps.PersonRepository;

                var foundPerson = await personRepository.GetPerson(personId);

                if (foundPerson == null)
                {
                    throw new PersonException(PersonExceptionType.PersonDoesNotExist);
                }

                return new PersonDto
                {
                    PersonId = foundPerson.PersonId,
                    FirstName = foundPerson.FirstName,
                    LastName = foundPerson.LastName,
                    Email = foundPerson.Email,
                    PhoneNumber = foundPerson.PhoneNumber,
                    ProfilePicture = foundPerson.ProfilePicture,
                    Location = foundPerson.Location,
                    IsAdmin = foundPerson.IsAdmin
                };
            };
    }
}