using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Validators
{
    public interface IValidator<TEntity, TDataDto>
        where TEntity : BaseEntity
        where TDataDto : IDataDto
    {
        void ValidateFind(TEntity character);
        void ValidateAddOrUpdate(TDataDto dto);
    }
}
