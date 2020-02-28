using Chilicki.StarWars.Data.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Chilicki.StarWars.Application.Dtos;

namespace Chilicki.StarWars.Application.Validators
{
    public class NullValidator
    {
        public void Validate(BaseEntity entity)
        {
            if (entity == null)
                throw new NotFoundException("Requested object not found");
        }

        public void Validate(IDataDto dataDto)
        {
            if (dataDto == null)
                throw new BadRequestException("Some request parameters hasn't been sent");
        }
    }
}
