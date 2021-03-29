using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace PersonApi
{
    public class PersonCosmosDbService : IPersonRepository
    {
        private readonly IMongoCollection<Person> _people;

        public PersonCosmosDbService()
        {
            var connectionString = Environment.GetEnvironmentVariable("COSMOS_DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Please supply the COSMOS_DB_CONNECTION_STRING");

            var databaseName = Environment.GetEnvironmentVariable("PERSON_DATABASE_NAME");
            if (string.IsNullOrEmpty(databaseName)) throw new Exception("Please supply the PERSON_DATABASE_NAME");

            var collectionName = Environment.GetEnvironmentVariable("PERSON_COLLECTION_NAME");
            if (string.IsNullOrEmpty(collectionName)) throw new Exception("Please supply the PERSON_COLLECTION_NAME");

            var config = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            config.SslSettings =
                new SslSettings {EnabledSslProtocols = SslProtocols.Tls12};

            var mongoClient = new MongoClient(config);

            var database = mongoClient.GetDatabase(databaseName);

            _people = database.GetCollection<Person>(collectionName);
        }

        public async Task<Person> CreatePerson(Person person)
        {
            await _people.InsertOneAsync(person);

            return person;
        }

        public async Task<Person> GetPerson(string id)
        {
            var foundPerson = await _people.FindAsync(person => person.Id == id);

            return foundPerson.FirstOrDefault();
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            var foundPerson = await _people.FindAsync(person => person.Email == email);

            return foundPerson.FirstOrDefault();
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            // TODO implement GetAllPeople
            throw new NotImplementedException();
        }

        public async Task<Person> UpdatePerson(string id, Person updatedPerson)
        {
            // TODO implement UpdatePerson
            throw new NotImplementedException();
        }

        public async Task DeletePerson(string id)
        {
            // TODO implement DeletePerson
            throw new NotImplementedException();
        }
    }
}