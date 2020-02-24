using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Factories
{
    public class CharacterFriendFactory
    {
        public CharacterFriend Create(Character character, Character friend)
        {
            return new CharacterFriend()
            {
                Character = character,
                Friend = friend,
            };
        }
    }
}
