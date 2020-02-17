using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.EntityConfigurations
{
    public class CharacterEpisodeConfiguration : IEntityTypeConfiguration<CharacterEpisode>
    {
        public void Configure(EntityTypeBuilder<CharacterEpisode> builder)
        {
            builder
                .HasKey(p => new { p.CharacterId, p.EpisodeId });

            builder
                .HasOne(p => p.Character)
                .WithMany(p => p.CharacterEpisodes)
                .HasForeignKey(p => p.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Episode)
                .WithMany(p => p.CharacterEpisodes)
                .HasForeignKey(p => p.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
