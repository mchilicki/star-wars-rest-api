using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Factories
{
    public interface IFactory<TEntity, TDataDto>
        where TEntity : BaseEntity
        where TDataDto : IDataDto     
    {
        Task<TEntity> Create(TDataDto dto);
    }
}
