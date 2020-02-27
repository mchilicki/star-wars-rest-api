using AutoMapper;
using Chilicki.StarWars.Application.Configurations.Automapper;
using Chilicki.StarWars.Application.Configurations.DependencyInjection;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Factories.Paging;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Configurations.DependencyInjection;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Tests.Configuration.DependencyInjection
{
    public class TestDependencyInjection : IDependencyInjectionConfiguration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            new ApplicationDependencyInjection().ConfigureAutomapper(services);
        }
    }
}
