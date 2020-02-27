using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Repositories
{
    public interface ICharacterFriendRepository
    {
        Task<IEnumerable<CharacterFriend>> GetAllAsync();
        Task<CharacterFriend> FindAsync(Guid characterId, Guid friendId);
        Task<CharacterFriend> AddAsync(CharacterFriend entity);
        void Remove(CharacterFriend entity);
    }
}