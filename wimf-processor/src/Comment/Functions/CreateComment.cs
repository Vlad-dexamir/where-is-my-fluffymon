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
using Comment.Utils.BuildResponse;
using CommentApi;


namespace Comment.Functions

{
    public class CreateComment
    {
        private readonly ICommentRepository _commentRepository;

        public CreateComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [FunctionName("CreateComment")]
        public async Task<object> CreateCommentHandler(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "create-comment")]
            HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("[CREATE_COMMENT_HANDLER] Retrieving createCommentRequest...");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createCommentRequest = JsonConvert.DeserializeObject<CreateCommentRequest>(requestBody);

                log.LogInformation("[CREATE_COMMENT_HANDLER] Validating createCommentRequest...");

                var validationResult = await new CreateCommentRequestValidator().ValidateAsync(createCommentRequest);

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
                    CommentRepository = _commentRepository
                };

                var createdComment = await CreateCommentUseCase.Execute(createCommentDeps, createCommentRequest);

                log.LogInformation("[CREATE_COMMENT_HANDLER] Comment created successfully");

                return BuildResponse.Success(createdComment);
            }
            catch (Exception exception)
            {
                log.LogError(exception.Message);

                return BuildResponse.Failure(HttpStatusCode.InternalServerError, new Error(
                    exception.Message
                ));
            }
        }
    }
}
