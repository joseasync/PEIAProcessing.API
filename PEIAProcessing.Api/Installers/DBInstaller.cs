using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PEIAProcessing.Api.Installers.Interfaces;
using PEIAProcessing.Domain.Entities;

namespace PEIAProcessing.Api.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            // Inject Class with connection to avoid IO.
            services.AddSingleton<ConnectionConfig>(new ConnectionConfig
            {
                DbPeiaProcessingConnection = configuration.GetConnectionString("PeiaProcessingConnection")
            });

        }
    }
}
