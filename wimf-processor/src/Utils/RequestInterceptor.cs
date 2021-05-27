using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Utils
{
    public static class RequestInterceptor<T>
    {
        public static async Task<object> InterceptBody(Stream body, Validator<T> validator)
        {
            var requestBody = await new StreamReader(body).ReadToEndAsync();

            var deserializedRequest = JsonConvert.DeserializeObject<T>(requestBody);

            var validationResult = await validator.ValidateAsync(deserializedRequest);

            if (!validationResult.IsValid)
            {
                return BuildResponse.Failure(
                    HttpStatusCode.BadRequest,
                    validationResult.Errors.Select(
                        e => new
                        {
                            Field = e.PropertyName,
                            Error = e.ErrorMessage
                        }));
            }

            return deserializedRequest as Task<T>;
        }
    }
}