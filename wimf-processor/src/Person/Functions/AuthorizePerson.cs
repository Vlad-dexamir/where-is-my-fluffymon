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
    public class AuthorizePerson
    {
        private readonly IPersonRepository _personRepository;

        public AuthorizePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [FunctionName("AuthorizePerson")]
        public async Task<object> AuthorizePersonHandler(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "person")]
            HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("[AUTHORIZE_PERSON_HANDLER] Retrieving authorizePersonRequest...");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var authorizePersonRequest = JsonConvert.DeserializeObject<AuthorizePersonRequest>(requestBody);

                log.LogInformation("[AUTHORIZE_PERSON_HANDLER] Validating authorizePersonRequest...");

                var validationResult =
                    await new AuthorizePersonRequestValidator().ValidateAsync(authorizePersonRequest);

                if (!validationResult.IsValid)
                    return BuildResponse.Failure(
                        HttpStatusCode.BadRequest,
                        validationResult.Errors.Select(
                            e => new
                            {
                                Field = e.PropertyName,
                                Error = e.ErrorMessage
                            }));

                log.LogInformation("[AUTHORIZE_PERSON_HANDLER] Authorizing person....");

                AuthorizePersonDeps authorizePersonDeps = new AuthorizePersonDeps
                {
                    PersonRepository = _personRepository
                };

                var personJwt = await AuthorizePersonUseCase.Execute(authorizePersonDeps, authorizePersonRequest);

                log.LogInformation("[AUTHORIZE_PERSON_HANDLER] Person is valid and is authorized");

                return BuildResponse.Success(personJwt);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);

                var isBadRequest =
                    exception.Message.Equals(PersonException.Exceptions[PersonExceptionType.PersonDoesNotExist]) ||
                    exception.Message.Equals(PersonException.Exceptions[PersonExceptionType.PersonInvalidCredentials]);

                if (isBadRequest)
                    return BuildResponse.Failure(HttpStatusCode.BadRequest, new Error(exception.Message));

                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(exception.Message));
            }
        }
    }
}