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
using Post.Utils.BuildResponse;
using PostApi;

namespace Post.Functions
{
    public class CreateComment
    {
        private readonly IPostRepository _postRepository;

        public CreateComment(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("CreateComment")]
        public async Task<object> CreateCommentHandler(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "create-comment")]
            HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("[CREATE_COMMENT_HANDLER] Retrieving createCommentRequest...");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createCommentRequest = JsonConvert.DeserializeObject<CreateCommentRequest>(requestBody);

                log.LogInformation("[CREATE_COMMENT_HANDLER] Validating createCommentRequest...");

                var validationResult = await new CreateCommentRequestValidator().ValidateAsync(createPersonRequest);

                if (!validationResult.IsValid)
                    return BuildResponse.Failure(
                        HttpStatusCode.BadRequest,
                        validationResult.Errors.Select(
                            e => new
                            {
                                Field = e.PropertyName,
                                Error = e.ErrorMessage
                            }));

                log.LogInformation("[CREATE_COMMENT_HANDLER] Creating comment...");

                CreateCommentDeps createCommentDeps = new CreateCommentDeps
                {
                    postRepository = _postRepository
                };

                var commentJwt = await CreateCommentUseCase.Execute(createCommentDeps, createCommentRequest);

                log.LogInformation("[CREATE_COMMENT_HANDLER] Comment created successfully");

                return BuildResponse.Success(personJwt);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);

               //To validate at a later date

                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(
                    exception.Message
                ));
            }
        }
    }
}
