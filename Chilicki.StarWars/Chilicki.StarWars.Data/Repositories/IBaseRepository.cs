using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Helpers.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseNamedEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetPageAsync(Pager pager);
        Task<TEntity> FindAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}