using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chilicki.StarWars.Data.Repositories;
using Chilicki.StarWars.Application.Validators;
using System.Threading.Tasks;
using Chilicki.StarWars.Application.Factories;

namespace Chilicki.StarWars.Application.Updaters
{
    public class CharacterUpdater : IUpdater<Character, CharacterDataDto>
    {
        private readonly IBaseRepository<Episode> episodeRepository;
        private readonly EpisodeValidator episodeValidator;
        private readonly CharacterEpisodeFactory characterEpisodeFactory;

        public CharacterUpdater(
            IBaseRepository<Episode> episodeRepository,
            EpisodeValidator episodeValidator,
            CharacterEpisodeFactory characterEpisodeFactory)
        {
            this.episodeRepository = episodeRepository;
            this.episodeValidator = episodeValidator;
            this.characterEpisodeFactory = characterEpisodeFactory;
        }

        public async Task<Character> Update(Character character, CharacterDataDto dto)
        {
            character.Name = dto.Name;
            if (character.CharacterEpisodes == null)
                character.CharacterEpisodes = new List<CharacterEpisode>();
            character.CharacterEpisodes.Clear();
            foreach (var episodeId in dto.EpisodeIds)
            {
                var episode = await episodeRepository.FindAsync(episodeId);
                episodeValidator.ValidateFind(episode);
                character.CharacterEpisodes.Add(characterEpisodeFactory.Create(character, episode));
            }
            return character;
        }
    }
}
