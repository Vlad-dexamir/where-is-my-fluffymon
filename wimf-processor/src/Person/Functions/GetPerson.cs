using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Person.Utils.BuildResponse;
using PersonApi;

namespace Person.Functions
{
    public class GetPerson
    {
        private readonly IPersonRepository _personRepository;

        public GetPerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [FunctionName("GetPerson")]
        public async Task<object> GetPersonHandler(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/{personId}")]
            HttpRequest req, ILogger log, string personId)
        {
            try
            {
                log.LogInformation("[GET_PERSON_HANDLER] Retrieving person...");

                GetPersonDeps getPersonDeps = new GetPersonDeps
                {
                    PersonRepository = _personRepository
                };

                var person = await GetPersonUseCase.Execute(getPersonDeps, personId);

                log.LogInformation(
                    $"[GET_PERSON_HANDLER] Person with personId:${personId} retrieved successfully");

                return BuildResponse.Success(person);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);

                if (exception.Message
                    .Equals(PersonException.Exceptions[PersonExceptionType.PersonDoesNotExist])
                )

                    return BuildResponse.Failure(HttpStatusCode.BadRequest, new Error(
                        exception.Message,
                        PersonExceptionType.PersonDoesNotExist
                    ));

                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(
                    exception.Message
                ));
            }
        }
    }
}
