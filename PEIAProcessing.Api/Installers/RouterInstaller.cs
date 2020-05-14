using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PEIAProcessing.Api.Installers.Interfaces;

namespace PEIAProcessing.Api.API.Installers
{
    public class RouterInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddHttpClient();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "PEIAProcessing API",
                        Version = "v1",
                        Description = "PEIAProcessing Endpoint Documentation",
                        Contact = new OpenApiContact
                        {
                            Name = "Jose Cruz",
                            Url = new Uri("http://www.josecruz.io/")
                        }
                    });
            });

        }
    }
}
