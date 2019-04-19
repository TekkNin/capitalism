using Capitalism.Batch.Logic.Processes;
using Capitalism.Infrastructure;
using Capitalism.Infrastructure.Repositories;
using Capitalism.Logic.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace Capitalism.Batch.CommandLine
{
    public class App
    {
        private readonly ILogger _logger;
        private readonly IDataAccessConfiguration _config;

        public App(IDataAccessConfiguration config, ILogger<App> logger)
        {
            _logger = logger;
            _config = config;
        }

        public void Run()
        {
            _logger.LogInformation($"Increase energy process executed at: {DateTime.Now}");

            IPlayerRepository playerRepository = new PlayerRepository(_config);

            new IncreaseEnergyProcess(playerRepository).Execute();

            System.Console.WriteLine("");
            System.Console.WriteLine("-----------------------------------------------");
            System.Console.WriteLine("Done! Please press any key to close the window.");

            _logger.LogInformation($"Increase energy process complete at: {DateTime.Now}");

            //System.Console.ReadKey();
        }
    }
}
