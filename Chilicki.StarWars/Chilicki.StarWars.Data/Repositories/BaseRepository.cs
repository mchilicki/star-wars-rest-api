using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
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
            return await entities.IncludeAll().ToListAsync();
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await entities.IncludeAll().SingleOrDefaultAsync(p => p.Id == id);
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
