using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Configurations.EntityConfigurations
{
    public class CharacterFriendConfiguration : IEntityTypeConfiguration<CharacterFriend>
    {
        public void Configure(EntityTypeBuilder<CharacterFriend> builder)
        {
            builder
                .HasKey(p => new { p.CharacterId, p.FriendId });

            builder
                .HasOne(p => p.Character)
                .WithMany(p => p.CharacterFriends)
                .HasForeignKey(p => p.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Friend)
                .WithMany()
                .HasForeignKey(p => p.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
