using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PEIAProcessing.Api.Installers.Interfaces;
using PEIAProcessing.Domain.Interfaces;
using PEIAProcessing.Service.Services;

namespace PEIAProcessing.Api.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IServiceDomain<>), typeof(BaseService<>));
        }
    }
}
