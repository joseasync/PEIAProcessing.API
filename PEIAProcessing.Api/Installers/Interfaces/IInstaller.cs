using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PEIAProcessing.Api.Installers.Interfaces
{
    public interface IInstaller
    {
        void InstallerServices(IServiceCollection services, IConfiguration configuration);
    }
}
