using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.EntityConfigurations
{
    public abstract class BaseNamedEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : BaseNamedEntity
    {
        public override void ConfigureEntity(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            ConfigureNamedEntity(builder);
        }

        public abstract void ConfigureNamedEntity(EntityTypeBuilder<TEntity> builder);
    }
}
