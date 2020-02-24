using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Repositories
{
    public class CharacterFriendRepository
    {
        protected DbContext context;
        protected DbSet<CharacterFriend> entities;

        public CharacterFriendRepository(DbContext context)
        {
            this.context = context;
            entities = this.context.Set<CharacterFriend>();
        }

        public async Task<IEnumerable<CharacterFriend>> GetAllAsync()
        {
            return await entities.IncludeAll().ToListAsync();
        }

        public async Task<CharacterFriend> FindAsync(Guid characterId, Guid friendId)
        {
            return await entities.IncludeAll().SingleOrDefaultAsync(
                p => p.CharacterId == characterId && p.FriendId == friendId);
        }

        public async Task<CharacterFriend> AddAsync(CharacterFriend entity)
        {
            var entry = await entities.AddAsync(entity);
            return entry.Entity;
        }

        public void Remove(CharacterFriend entity)
        {
            entities.Remove(entity);
        }
    }

    public static class CharacterFriendRepositoryExtensions
    {
        public static IQueryable<CharacterFriend> IncludeAll(this IQueryable<CharacterFriend> query)
        {
            return query
                .Include(p => p.Character)
                .Include(p => p.Friend);
        }
    }
}
