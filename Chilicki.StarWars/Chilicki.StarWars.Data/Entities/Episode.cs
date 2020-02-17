using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Entities
{
    public class Episode : BaseNamedEntity
    {
        public virtual ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}
