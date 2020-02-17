using Chilicki.StarWars.Application.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class NullValidator
    {
        public void Validate(BaseEntity entity)
        {
            if (entity == null)
                throw new NotFoundException($"{typeof(BaseEntity).Name} not found");
        }
    }
}
