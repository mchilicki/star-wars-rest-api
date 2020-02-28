using Chilicki.StarWars.Data.Helpers.Exceptions;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public class NullValidator
    {
        public void Validate(object obj)
        {
            if (obj == null)
                throw new BadRequestException("Some request parameters hasn't been sent");
        }
    }
}
