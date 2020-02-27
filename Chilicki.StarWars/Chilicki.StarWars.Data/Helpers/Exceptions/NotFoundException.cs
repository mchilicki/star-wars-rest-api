using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Helpers.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
