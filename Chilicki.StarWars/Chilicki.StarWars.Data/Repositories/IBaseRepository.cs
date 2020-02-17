using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}