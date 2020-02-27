using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Helpers.Exceptions;
using Chilicki.StarWars.Data.Helpers.Extensions;
using Chilicki.StarWars.Data.Helpers.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseNamedEntity
    {
        protected DbContext context;
        protected DbSet<TEntity> entities;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            entities = this.context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities
                .IncludeAll()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPageAsync(Pager pager)
        {            
            var entitiesCount = await entities.CountAsync();
            if (pager.CurrentPage < 1 || entitiesCount <= pager.EntitiesToSkip)
                throw new NotFoundException($"Page {pager.CurrentPage} doesn't exist");
            return await entities
                .IncludeAll()
                .OrderBy(p => p.Name)
                .Skip(pager.EntitiesToSkip.Value)
                .Take(pager.PageSize.Value)
                .ToListAsync();
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await entities
                .IncludeAll()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await entities.AddAsync(entity);
            return entry.Entity;
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }   
    }
}
