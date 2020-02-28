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
        private readonly NullValidator nullValidator;

        public CharacterValidator(
            NullValidator validator)
        {
            this.nullValidator = validator;
        }

        public void ValidateFind(Character character)
        {
            nullValidator.Validate(character);
        }

        public void ValidateAddOrUpdate(CharacterDataDto dto)
        {
            nullValidator.Validate(dto);
        }
    }
}
