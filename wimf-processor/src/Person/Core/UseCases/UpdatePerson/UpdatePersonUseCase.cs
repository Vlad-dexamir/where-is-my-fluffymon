using System;
using System.Threading.Tasks;
using Utils;

namespace PersonApi
{
    public static class UpdatePersonUseCase
    {
        public static readonly Func<UpdatePersonDeps, string, UpdatePersonRequest, Task<PersonDto>> Execute =
            async (updatePersonDeps, personId, updatePersonRequest) =>
            {
                var personRepository = updatePersonDeps.PersonRepository;

                var foundPerson = await personRepository.GetPerson(personId);

                if (foundPerson == null) throw new PersonException(PersonExceptionType.PersonDoesNotExist);

                var updatedPerson = foundPerson;

                UpdatePersonRequestUpdates updates = updatePersonRequest.Updates;

                if (updates.LastName is {Action: UpdateActionType.Put})
                    updatedPerson.LastName = updates.LastName.Value;

                if (updates.Location is {Action: UpdateActionType.Put})
                    updatedPerson.Location = updates.Location.Value;

                if (updates.Password is {Action: UpdateActionType.Put})
                    updatedPerson.Password = BCrypt.Net.BCrypt.HashPassword(updates.Password.Value);

                if (updates.ProfilePicture != null)
                    updatedPerson.ProfilePicture = updates.ProfilePicture.Action == UpdateActionType.Put
                        ? updates.ProfilePicture.Value
                        : null;
                if (updates.PhoneNumber != null)
                    updatedPerson.PhoneNumber = updates.PhoneNumber.Action == UpdateActionType.Put
                        ? updates.PhoneNumber.Value
                        : null;

                await personRepository.UpdatePerson(personId, updatedPerson);

                return new PersonDto
                {
                    PersonId = updatedPerson.PersonId,
                    FirstName = updatedPerson.FirstName,
                    LastName = updatedPerson.LastName,
                    Email = updatedPerson.Email,
                    PhoneNumber = updatedPerson.PhoneNumber,
                    ProfilePicture = updatedPerson.ProfilePicture,
                    Location = updatedPerson.Location,
                    IsAdmin = updatedPerson.IsAdmin
                };
            };
    }
}