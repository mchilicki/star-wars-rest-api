using AutoMapper;
using Chilicki.StarWars.Application.Configurations.Automapper;
using Chilicki.StarWars.Data.Configurations.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Configurations.DependencyInjection
{
    public class ApplicationDependencyInjection : IDependencyInjectionConfiguration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureServices(services);
            ConfigureFactories(services);
            ConfigureAutomapper(services);
            ConfigureValidators(services);
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            
        }

        private void ConfigureServices(IServiceCollection services)
        {
            
        }

        private void ConfigureFactories(IServiceCollection services)
        {
            
        }

        private void ConfigureAutomapper(IServiceCollection services)
        {
            var container = services.BuildServiceProvider();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ConstructServicesUsing(type => container.GetRequiredService(type));
                mc.AddProfile(new AutomapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
