﻿using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Dtos.Friends;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Dtos.Characters
{
    public class CharacterDto : NamedEntityDto
    {
        public IEnumerable<EpisodeDto> Episodes { get; set; }
        public IEnumerable<FriendDto> Friends { get; set; }
    }
}
