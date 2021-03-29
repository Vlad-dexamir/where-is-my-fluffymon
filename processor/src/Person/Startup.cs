using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Person.Config;
using PersonApi;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Person.Config
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder => { loggingBuilder.AddFilter(_ => true); });

            builder.Services.AddSingleton<IPersonRepository, PersonCosmosDbService>();
        }
    }
}