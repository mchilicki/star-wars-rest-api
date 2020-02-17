using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Factories
{
    public class CharacterFactory : IFactory<Character, CharacterDataDto>
    {
        private readonly CharacterUpdater characterUpdater;

        public CharacterFactory(
            CharacterUpdater characterUpdater)
        {
            this.characterUpdater = characterUpdater;
        }

        public Character Create(CharacterDataDto dto)
        {
            var character = new Character();
            return characterUpdater.Update(character, dto);
        }
    }
}
