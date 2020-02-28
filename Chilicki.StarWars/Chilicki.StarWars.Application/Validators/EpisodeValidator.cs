using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Data.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class EpisodeValidator : IValidator<Episode, EpisodeDataDto>
    {
        private readonly NullValidator nullValidator;
        private readonly NameValidator nameValidator;

        public EpisodeValidator(
            NullValidator nullValidator,
            NameValidator nameValidator)
        {
            this.nullValidator = nullValidator;
            this.nameValidator = nameValidator;
        }

        public void ValidateFind(Episode entity)
        {
            nullValidator.Validate(entity);
        }

        public void ValidateAddOrUpdate(EpisodeDataDto dto)
        {
            nullValidator.Validate(dto);
            nameValidator.Validate(dto.Name);
        }
    }
}
