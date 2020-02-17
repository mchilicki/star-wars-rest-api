using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Updaters
{
    public interface IUpdater<TEntity, TDataDto>
        where TEntity : BaseEntity
        where TDataDto : IDataDto
    {
        Task<TEntity> Update(TEntity entity, TDataDto dto);
    }
}
