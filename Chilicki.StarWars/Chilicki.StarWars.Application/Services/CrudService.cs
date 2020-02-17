using AutoMapper;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Services
{
    public class CrudService<TEntity, TDto, TDataDto, TFactory, TUpdater, TValidator>  
        where TEntity : BaseEntity
        where TDto : IDto
        where TDataDto : IDataDto
        where TFactory : IFactory<TEntity, TDataDto>
        where TUpdater : IUpdater<TEntity, TDataDto>
        where TValidator : IValidator<TEntity, TDataDto>
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<TEntity> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly TValidator validator;
        private readonly TFactory factory;
        private readonly TUpdater updater;

        public CrudService(
            IMapper mapper,
            IBaseRepository<TEntity> repository,
            IUnitOfWork unitOfWork,
            TValidator validator,
            TFactory factory,
            TUpdater updater)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.factory = factory;
            this.updater = updater;
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<TDto>>(entities);
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
