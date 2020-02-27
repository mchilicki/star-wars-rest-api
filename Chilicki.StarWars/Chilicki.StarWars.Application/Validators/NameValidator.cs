using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Data.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class NameValidator 
    {
        private readonly int NAME_MAX_CHARACTERS = 100;

        public void Validate(NamedDataDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new BadRequestException("Name is empty.");
            if (dto.Name.Length > NAME_MAX_CHARACTERS)
                throw new BadRequestException($"Name is too long. Maximum length is {NAME_MAX_CHARACTERS} characters.");
        }
    }
}
