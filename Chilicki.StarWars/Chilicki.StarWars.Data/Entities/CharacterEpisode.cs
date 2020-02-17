using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Entities
{
    public class CharacterEpisode
    {
        public Guid CharacterId { get; set; }
        public Guid EpisodeId { get; set; }
        public Character Character { get; set; }
        public Episode Episode { get; set; }
    }
}
