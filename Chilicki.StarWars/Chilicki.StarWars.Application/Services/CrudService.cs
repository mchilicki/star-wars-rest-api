using AutoMapper;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Factories.Paging;
using Chilicki.StarWars.Application.Helpers.Paging;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Helpers.Paging;
using Chilicki.StarWars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Services
{
    public class CrudService<TEntity, TDto, TDataDto, TFactory, TUpdater, TValidator>  
        where TEntity : BaseNamedEntity
        where TDto : IDto
        where TDataDto : IDataDto
        where TFactory : IFactory<TEntity, TDataDto>
        where TUpdater : IUpdater<TEntity, TDataDto>
        where TValidator : IValidator<TEntity, TDataDto>
    {
        private readonly IMapper mapper;        
        private readonly IUnitOfWork unitOfWork;
        private readonly TValidator validator;
        private readonly TFactory factory;
        private readonly TUpdater updater;
        private readonly IBaseRepository<TEntity> repository;
        private readonly PageFactory<TDto> pageFactory;

        public CrudService(
            IMapper mapper,            
            IUnitOfWork unitOfWork,
            TValidator validator,
            TFactory factory,
            TUpdater updater,
            IBaseRepository<TEntity> repository,
            PageFactory<TDto> pageFactory)
        {
            this.mapper = mapper;            
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.factory = factory;
            this.updater = updater;
            this.repository = repository;
            this.pageFactory = pageFactory;
        }        

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<Page<TDto>> GetPage(Pager pager)
        {
            var entities = await repository.GetPageAsync(pager);
            var entityDtos = mapper.Map<IEnumerable<TDto>>(entities);
            return pageFactory.Create(entityDtos, pager);
        }

        public async Task<TDto> Find(Guid id)
        {
            var entity = await repository.FindAsync(id);
            validator.ValidateFind(entity);
            return mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Create(TDataDto dto)
        {
            validator.ValidateAddOrUpdate(dto);
            var entity = await factory.Create(dto);
            var addedEntity = await repository.AddAsync(entity);
            await unitOfWork.SaveAsync();
            return mapper.Map<TDto>(addedEntity);
        }

        public async Task Update(Guid id, TDataDto dto)
        {
            validator.ValidateAddOrUpdate(dto);
            var entity = await repository.FindAsync(id);
            validator.ValidateFind(entity);
            await updater.Update(entity, dto);
            await unitOfWork.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await repository.FindAsync(id);
            if (entity == null)
                return;
            repository.Remove(entity);
            await unitOfWork.SaveAsync();
        }
    }
}
