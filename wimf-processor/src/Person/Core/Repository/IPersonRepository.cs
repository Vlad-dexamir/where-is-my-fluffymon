using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi
{
    public interface IPersonRepository
    {
        public Task<Person> CreatePerson(Person person);
        
        public Task<Person> GetPerson(string personId);
        
        public Task<Person> GetPersonByEmail(string email);
        
        
        public Task UpdatePerson(string personId, Person updatedPerson);
        
    }
}
