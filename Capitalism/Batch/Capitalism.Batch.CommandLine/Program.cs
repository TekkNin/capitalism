using Capitalism.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Capitalism.Batch.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Run app
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            serviceCollection.AddSingleton(new LoggerFactory().AddConsole());
            serviceCollection.AddLogging();

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IDataAccessConfiguration, BatchConfiguration>();

            // Add app
            serviceCollection.AddTransient<App>();
        }
    }
}
