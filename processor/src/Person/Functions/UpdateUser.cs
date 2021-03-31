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
	public class UpdatePerson
	{
		private readonly IPersonRepository _personRepository;
		public UpdatePerson(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}
		[FunctionName("UpdatePerson")]
		public async Task<object> UpdatePersonHandler(
			[HttpTriggerAuthorizationLevel.Function, "put", Route = "person/{personId}")]
			HttpRequest req, ILogger log, string personId)
        {
            try
			{
				log.LogInformation("[UPDATE_PERSON_HANDLER] Retrieving updatePersonRequest...");

				var person = await UpdatePersonUseCase.Execute(_personRepository, personId);

			}
            catch
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
