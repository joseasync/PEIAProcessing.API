using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PEIAProcessing.Api.Installers.Interfaces;

namespace PEIAProcessing.Api.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            //Inicia e instala todos os installers de uma vez.
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)//Get all class that implements IInstaller
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();//Create a instance of each one, saving in a list.

            installers.ForEach(installer => installer.InstallerServices(services, configuration));//Initialize
        }
    }
}
