using Chilicki.StarWars.Data.Configurations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Databases
{
    public class StarWarsDbContext : DbContext
    {
        public StarWarsDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        }
    }
}
