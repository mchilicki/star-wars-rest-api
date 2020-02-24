using Chilicki.StarWars.Application.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class CharacterFriendValidator
    {
        public void ValidateAdd(Character character, Character friend)
        {
            if (character == null)
                throw new BadRequestException("Wrong character");
            if (friend == null)
                throw new BadRequestException("Wrong friend");
            if (character.Id == friend.Id)
                throw new BadRequestException("Character and friend are the same character");
        }
    }
}
