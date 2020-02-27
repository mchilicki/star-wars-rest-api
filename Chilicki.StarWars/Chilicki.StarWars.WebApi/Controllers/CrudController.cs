using System;
using System.Threading.Tasks;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Services;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Helpers.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.StarWars.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController<TEntity, TDto, TDataDto, TFactory, TUpdater, TValidator> : ControllerBase
        where TEntity : BaseNamedEntity
        where TDto : IDto
        where TDataDto : IDataDto
        where TFactory : IFactory<TEntity, TDataDto>
        where TUpdater : IUpdater<TEntity, TDataDto>
        where TValidator : IValidator<TEntity, TDataDto>
    {
        protected readonly CrudService<TEntity, TDto, TDataDto, TFactory, TUpdater, TValidator> service;

        public CrudController(
            CrudService<TEntity, TDto, TDataDto, TFactory, TUpdater, TValidator> service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int? currentPage, int? pageSize)
        {
            if (currentPage == null || pageSize == null)
                return Ok(await service.GetAll());
            return Ok(await service.GetPage(new Pager(currentPage, pageSize)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await service.Find(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TDataDto dto)
        {
            var character = await service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = character.Id }, character);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] TDataDto dto)
        {
            await service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return NoContent();
        }
    }
}