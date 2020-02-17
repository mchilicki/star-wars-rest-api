using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.EntityConfigurations
{
    public class CharacterConfiguration : BaseEntityConfiguration<Character>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Character> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
