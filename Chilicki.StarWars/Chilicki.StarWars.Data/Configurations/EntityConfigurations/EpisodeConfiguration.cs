using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.EntityConfigurations
{
    public class EpisodeConfiguration : BaseNamedEntityConfiguration<Episode>
    {
        public override void ConfigureNamedEntity(EntityTypeBuilder<Episode> builder)
        {
            
        }
    }
}
