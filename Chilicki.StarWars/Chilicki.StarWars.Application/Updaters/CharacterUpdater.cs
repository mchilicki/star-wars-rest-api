using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Updaters
{
    public class CharacterUpdater : IUpdater<Character, CharacterDataDto>
    {
        public Character Update(Character character, CharacterDataDto dto)
        {
            character.Name = dto.Name;
            return character;
        }
    }
}
