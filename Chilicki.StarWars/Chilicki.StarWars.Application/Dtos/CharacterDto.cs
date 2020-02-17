using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Dtos
{
    public class CharacterDto : EntityDto, IDto
    {
        public string Name { get; set; }
    }
}
