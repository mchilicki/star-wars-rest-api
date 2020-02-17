using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class CharacterValidator : IValidator<Character, CharacterDataDto>
    {
        private readonly int NAME_MAX_CHARACTERS = 100;

        public void Validate(Character character)
        {
            if (character == null)
                throw new NotFoundException("Character not found");
        }

        public void Validate(CharacterDataDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new InvalidCharacterException("Character name is empty.");
            if (dto.Name.Length > NAME_MAX_CHARACTERS)
                throw new InvalidCharacterException($"Character name is too long. Maximum length is {NAME_MAX_CHARACTERS} characters.");
        }
    }
}
