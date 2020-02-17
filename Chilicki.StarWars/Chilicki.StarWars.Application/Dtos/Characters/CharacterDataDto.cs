using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Dtos.Characters
{
    public class CharacterDataDto : NamedDataDto 
    {
        public IEnumerable<Guid> EpisodeIds { get; set; }
    }
}
