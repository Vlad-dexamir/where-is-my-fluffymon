using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Comment.Config;
using CommentApi;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Comment.Config
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder => { loggingBuilder.AddFilter(_ => true); });

            builder.Services.AddSingleton<ICommentRepository, CommentCosmosDbService>();
        }
    }
}