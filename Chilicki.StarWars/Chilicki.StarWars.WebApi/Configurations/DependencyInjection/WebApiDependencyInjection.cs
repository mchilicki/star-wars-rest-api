using Chilicki.StarWars.Application.Configurations.DependencyInjection;
using Chilicki.StarWars.Data.Configurations.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.StarWars.WebApi.Configurations.DependencyInjection
{
    public class WebApiDependencyInjection : IDependencyInjectionConfiguration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            RegisterControllers(services);
            RegisterSwagger(services);
            new ApplicationDependencyInjection().Register(services, configuration);
            new DataDependencyInjection().Register(services, configuration);
        }

        private void RegisterControllers(IServiceCollection services)
        {
            services.AddControllers();
        }

        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "1.0",
                    Title = "Star Wars - Code&Pepper Recruitment Task",
                });
            });
        }
    }
}
