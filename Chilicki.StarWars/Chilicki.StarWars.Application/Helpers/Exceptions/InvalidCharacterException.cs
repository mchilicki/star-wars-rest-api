using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Helpers.Exceptions
{
    public class InvalidCharacterException : BadRequestException
    {
        public InvalidCharacterException(string message) : base(message)
        {
        }
    }
}
