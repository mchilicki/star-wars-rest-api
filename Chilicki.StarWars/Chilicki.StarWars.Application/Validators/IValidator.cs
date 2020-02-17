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
        void Validate(TEntity character);
        void Validate(TDataDto dto);
    }
}
