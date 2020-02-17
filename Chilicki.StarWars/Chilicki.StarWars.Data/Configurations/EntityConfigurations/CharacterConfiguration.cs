using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chilicki.StarWars.Data.Configurations.EntityConfigurations
{
    public class CharacterConfiguration : BaseNamedEntityConfiguration<Character>
    {
        public override void ConfigureNamedEntity(EntityTypeBuilder<Character> builder)
        {
            
        }
    }
}
