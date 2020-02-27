using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Data.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class CharacterValidator : IValidator<Character, CharacterDataDto>
    {
        private readonly NullValidator validator;

        public CharacterValidator(
            NullValidator validator)
        {
            this.validator = validator;
        }

        public void ValidateFind(Character character)
        {
            validator.Validate(character);
        }

        public void ValidateAddOrUpdate(CharacterDataDto dto)
        {
            
        }
    }
}
