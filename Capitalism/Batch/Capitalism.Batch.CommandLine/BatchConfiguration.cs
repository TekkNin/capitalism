using Capitalism.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Capitalism.Batch.CommandLine
{
    public class BatchConfiguration : IDataAccessConfiguration
    {
        protected IConfiguration Configuration;

        public BatchConfiguration(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string ConnectionString => this.Configuration.GetConnectionString("DefaultConnection");
    }
}
