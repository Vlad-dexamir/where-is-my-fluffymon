using System.Threading.Tasks;

namespace PersonApi
{
    public interface IPersonRepository
    {
        public Task<Person> CreatePerson(Person person);

        public Task<Person> GetPersonByEmail(string email);
    }
}