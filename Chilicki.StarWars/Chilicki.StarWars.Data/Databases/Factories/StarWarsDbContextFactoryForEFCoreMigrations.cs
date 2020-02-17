using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Databases.Factories
{
    public class StarWarsDbContextFactoryForEFCoreMigrations : IDesignTimeDbContextFactory<StarWarsDbContext>
    {
        public StarWarsDbContext CreateDbContext(string[] args)
        {
            var databaseConnectionString = "data source=localhost;initial catalog=StarWarsDb;integrated security=True;MultipleActiveResultSets=True;";
            var optionsBuilder = new DbContextOptionsBuilder<StarWarsDbContext>();
            optionsBuilder.UseSqlServer(
                databaseConnectionString,
                b => b.MigrationsAssembly(typeof(StarWarsDbContext).Assembly.GetName().Name)
            );
            return new StarWarsDbContext(optionsBuilder.Options);
        }
    }
}
