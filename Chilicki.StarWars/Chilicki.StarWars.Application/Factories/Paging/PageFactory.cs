using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Helpers.Paging;
using Chilicki.StarWars.Data.Helpers.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Factories.Paging
{
    public class PageFactory<TDto> where TDto : IDto
    {
        public Page<TDto> Create(IEnumerable<TDto> dtos, Pager pager)
        {
            return new Page<TDto>()
            {
                CurrentPage = pager.CurrentPage.Value,
                PageSize = pager.PageSize.Value,
                Items = dtos,
            };
        }
    }
}
