using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Post.Config;
using PostApi;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Post.Config
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder => { loggingBuilder.AddFilter(_ => true); });

            builder.Services.AddSingleton<IPostRepository, PostCosmosDbService>();
        }
    }
}