using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Dtos
{
    public abstract class EntityDto : IDto
    {
        public Guid Id { get; set; }
    }
}
