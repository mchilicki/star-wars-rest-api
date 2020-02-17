using Chilicki.StarWars.Application.Dtos.Episodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Dtos.Characters
{
    public class CharacterDto : NamedEntityDto
    {
        public IEnumerable<EpisodeDto> Episodes { get; set; }
    }
}
