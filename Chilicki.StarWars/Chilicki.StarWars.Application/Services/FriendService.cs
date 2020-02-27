using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Services
{
    public class FriendService
    {
        private readonly IBaseRepository<Character> characterRepository;
        private readonly CharacterFriendFactory characterFriendFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICharacterFriendRepository characterFriendRepository;
        private readonly CharacterFriendValidator characterFriendValidator;

        public FriendService(
            IBaseRepository<Character> characterRepository,
            CharacterFriendFactory characterFriendFactory,
            IUnitOfWork unitOfWork,
            ICharacterFriendRepository characterFriendRepository,
            CharacterFriendValidator characterFriendValidator)
        {
            this.characterRepository = characterRepository;
            this.characterFriendFactory = characterFriendFactory;
            this.unitOfWork = unitOfWork;
            this.characterFriendRepository = characterFriendRepository;
            this.characterFriendValidator = characterFriendValidator;
        }

        public async Task AddFriend(Guid characterId, Guid friendId)
        {
            var characterFriendEntity = await characterFriendRepository.FindAsync(characterId, friendId);
            if (characterFriendEntity != null)
                return;
            var character = await characterRepository.FindAsync(characterId);
            var friend = await characterRepository.FindAsync(friendId);
            characterFriendValidator.ValidateAdd(character, friend);
            var characterFriend = characterFriendFactory.Create(character, friend);
            await characterFriendRepository.AddAsync(characterFriend);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteFriend(Guid characterId, Guid friendId)
        {
            var characterFriend = await characterFriendRepository.FindAsync(characterId, friendId);
            if (characterFriend == null)
                return;
            characterFriendRepository.Remove(characterFriend);
            await unitOfWork.SaveAsync();
        }
    }
}
