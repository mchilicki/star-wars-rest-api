using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Helpers.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
