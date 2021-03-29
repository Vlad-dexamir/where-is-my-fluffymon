using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi
{
    public interface IPersonRepository
    {
        public Task<Person> CreatePerson(Person person);
        public Task<Person> GetPerson(string id);
        public Task<Person> GetPersonByEmail(string email);
        public Task<IEnumerable<Person>> GetAllPeople();
        public Task<Person> UpdatePerson(string id, Person updatedPerson);
        public Task DeletePerson(string id);
    }
}