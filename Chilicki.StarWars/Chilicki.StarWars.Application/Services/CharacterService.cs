using AutoMapper;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Services.Base;
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
        private readonly IBaseRepository<Character> characterRepository;
        private readonly IUnitOfWork unitOfWork;

        public CharacterService(
            IMapper mapper,
            IBaseRepository<Character> characterRepository,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.characterRepository = characterRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CharacterDto>> GetAll()
        {
            var characters = await characterRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CharacterDto>>(characters);
        }

        public async Task<CharacterDto> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterDto> Create(CharacterDataDto dto)
        {
            throw new NotImplementedException();

        }

        public async Task Update(Guid id, CharacterDataDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
