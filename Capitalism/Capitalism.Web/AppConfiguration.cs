using Capitalism.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Capitalism.Web
{
    public class AppConfiguration : IDataAccessConfiguration
    {
        protected IConfiguration Configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string ConnectionString => this.Configuration.GetConnectionString("DefaultConnection");
    }
}
