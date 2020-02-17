using AutoMapper;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Services.Base;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<Character> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly CharacterValidator validator;
        private readonly CharacterFactory factory;
        private readonly CharacterUpdater updater;

        public CharacterService(
            IMapper mapper,
            IBaseRepository<Character> repository,
            IUnitOfWork unitOfWork,
            CharacterValidator validator,
            CharacterFactory factory,
            CharacterUpdater updater)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.factory = factory;
            this.updater = updater;
        }

        public async Task<IEnumerable<CharacterDto>> GetAll()
        {
            var characters = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<CharacterDto>>(characters);
        }

        public async Task<CharacterDto> Find(Guid id)
        {
            var character = await repository.FindAsync(id);
            validator.Validate(character);
            return mapper.Map<CharacterDto>(character);
        }

        public async Task<CharacterDto> Create(CharacterDataDto dto)
        {
            validator.Validate(dto);
            var character = factory.Create(dto);
            var addedCharacter = await repository.AddAsync(character);
            await unitOfWork.SaveAsync();
            return mapper.Map<CharacterDto>(addedCharacter);
        }

        public async Task Update(Guid id, CharacterDataDto dto)
        {
            validator.Validate(dto);
            var character = await repository.FindAsync(id);
            validator.Validate(character);
            updater.Update(character, dto);
            await unitOfWork.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var character = await repository.FindAsync(id);
            if (character == null)
                return;
            repository.Remove(character);
            await unitOfWork.SaveAsync();
        }
    }
}
