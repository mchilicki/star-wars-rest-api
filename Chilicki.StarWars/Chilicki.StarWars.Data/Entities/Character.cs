using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Entities
{
    public class Character : BaseNamedEntity
    {
        public virtual ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}
