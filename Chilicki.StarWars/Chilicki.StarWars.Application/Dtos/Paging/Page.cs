using Chilicki.StarWars.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Helpers.Paging
{
    public class Page<TDto> where TDto : IDto
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<TDto> Items { get; set; }
    }
}
