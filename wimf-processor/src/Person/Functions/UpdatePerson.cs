using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PersonApi;
using Utils;

namespace Person.Functions
{
    public class UpdatePerson
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        
        [FunctionName("UpdatePerson")]
        public async Task<object> UpdatePersonHandler(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "person/{personId}")]
            HttpRequest req, ILogger log, string personId)
        {
            try
            {
                log.LogInformation("[UPDATE_PERSON_HANDLER] Retrieving updatePersonRequest...");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var updatePersonRequest = JsonConvert.DeserializeObject<UpdatePersonRequest>(requestBody);
                
                log.LogInformation("[UPDATE_PERSON_HANDLER] Validating updatePersonRequest...");

                var validationResult = await new UpdatePersonRequestValidator().ValidateAsync(updatePersonRequest);

                if (!validationResult.IsValid)
                    return BuildResponse.Failure(
                        HttpStatusCode.BadRequest,
                        validationResult.Errors.Select(
                            e => new
                            {
                                Field = e.PropertyName,
                                Error = e.ErrorMessage
                            }));

                log.LogInformation("[UPDATE_PERSON_HANDLER] Updating person...");

                UpdatePersonDeps updatePersonDeps = new UpdatePersonDeps
                {
                    PersonRepository = _personRepository
                };

                var updatedPerson = await UpdatePersonUseCase.Execute(updatePersonDeps, personId , updatePersonRequest);

                log.LogInformation("[UPDATE_PERSON_HANDLER] Person updated successfully");

                return BuildResponse.Success(updatedPerson);
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