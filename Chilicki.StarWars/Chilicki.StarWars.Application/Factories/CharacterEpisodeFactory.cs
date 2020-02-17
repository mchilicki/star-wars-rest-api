using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Factories
{
    public class CharacterEpisodeFactory
    {
        public CharacterEpisode Create(Character character, Episode episode)
        {
            return new CharacterEpisode()
            {
                Character = character,
                Episode = episode,
            };
        }
    }
}
