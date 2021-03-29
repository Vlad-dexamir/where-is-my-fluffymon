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
using Person.Utils.BuildResponse;
using PersonApi;

namespace Person.Functions
{
    public class CreatePerson
    {
        private readonly IPersonRepository _personRepository;

        public CreatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [FunctionName("CreatePerson")]
        public async Task<object> CreatePersonHandler(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "create-person")]
            HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("[CREATE_PERSON_HANDLER] Retrieving createPersonRequest...");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var createPersonRequest = JsonConvert.DeserializeObject<CreatePersonRequest>(requestBody);

                log.LogInformation("[CREATE_PERSON_HANDLER] createPersonRequest:" +
                                   $"{createPersonRequest.FirstName}, {createPersonRequest.LastName}, {createPersonRequest.Email}, {createPersonRequest.Password}, {createPersonRequest.Location}");

                log.LogInformation("[CREATE_PERSON_HANDLER] Validating createPersonRequest...");

                var validationResult = await new CreatePersonRequestValidator().ValidateAsync(createPersonRequest);

                log.LogInformation(validationResult.ToString());
                if (!validationResult.IsValid)
                    return BuildResponse.Failure(
                        HttpStatusCode.BadRequest,
                        validationResult.Errors.Select(
                            e => new
                            {
                                Field = e.PropertyName,
                                Error = e.ErrorMessage
                            }));

                log.LogInformation("[CREATE_PERSON_HANDLER] Creating person...");

                var personJwt = await CreatePersonUseCase.Execute(_personRepository, createPersonRequest);

                log.LogInformation("[CREATE_PERSON_HANDLER] Person created successfully");

                return BuildResponse.Success(personJwt);
            }
            catch (Exception exception)
            {
                log.LogInformation(exception.Message);

                return
                    BuildResponse.Failure(
                        exception.Message.Equals(
                            PersonException.PersonExceptions[PersonExceptionType.PersonAlreadyExists])
                            ? HttpStatusCode.BadRequest
                            : HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}