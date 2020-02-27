using Chilicki.StarWars.Data.Databases;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.DependencyInjection
{
    public class DataDependencyInjection
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            RegisterDatabases(services, configuration);
            RegisterRepositories(services);
        }

        private void RegisterDatabases(IServiceCollection services, IConfiguration configuration)
        {
            var databaseConnectionString = configuration.GetConnectionString("StarWars");
            services.AddDbContext<DbContext, StarWarsDbContext>(options => options
                .UseSqlServer(
                    databaseConnectionString,
                    b => b.MigrationsAssembly(typeof(StarWarsDbContext).Assembly.GetName().Name
                ))
                .UseLazyLoadingProxies()
            );
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<BaseNamedEntity>, BaseRepository<BaseNamedEntity>>();
            services.AddScoped<IBaseRepository<Character>, CharacterRepository>();
            services.AddScoped<IBaseRepository<Episode>, EpisodeRepository>();
            services.AddScoped<CharacterFriendRepository>();
        }
    }
}
