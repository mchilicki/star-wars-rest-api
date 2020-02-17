using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.DependencyInjection
{
    public interface IDependencyInjectionConfiguration
    {
        void Register(IServiceCollection services, IConfiguration configuration);
    }
}
