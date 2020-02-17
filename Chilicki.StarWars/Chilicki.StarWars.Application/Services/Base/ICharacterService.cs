using Chilicki.StarWars.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Services.Base
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetAll();
        Task<CharacterDto> Find(Guid id);
        Task<CharacterDto> Create(CharacterDataDto dto);
        Task Update(Guid id, CharacterDataDto dto);
        Task Delete(Guid id);
    }
}
