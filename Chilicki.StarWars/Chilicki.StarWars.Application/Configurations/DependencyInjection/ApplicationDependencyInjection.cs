using AutoMapper;
using Chilicki.StarWars.Application.Configurations.Automapper;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Services;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Configurations.DependencyInjection;
using Chilicki.StarWars.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CrudService<Character, CharacterDto, CharacterDataDto,
                CharacterFactory, CharacterUpdater, CharacterValidator>>();
            services.AddScoped<CrudService<Episode, EpisodeDto, EpisodeDataDto,
                EpisodeFactory, EpisodeUpdater, EpisodeValidator>>();
            services.AddScoped<FriendService>();
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddScoped<NullValidator>();
            services.AddScoped<NameValidator>();
            services.AddScoped<CharacterValidator>();
            services.AddScoped<EpisodeValidator>();
        }

        private void ConfigureFactories(IServiceCollection services)
        {
            services.AddScoped<CharacterFactory>();
            services.AddScoped<CharacterUpdater>();
            services.AddScoped<EpisodeFactory>();
            services.AddScoped<EpisodeUpdater>();
            services.AddScoped<CharacterEpisodeFactory>();
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
