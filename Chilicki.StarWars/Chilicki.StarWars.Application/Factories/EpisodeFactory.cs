using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.StarWars.Application.Factories
{
    public class EpisodeFactory : IFactory<Episode, EpisodeDataDto>
    {
        private readonly EpisodeUpdater episodeUpdater;

        public EpisodeFactory(
            EpisodeUpdater episodeUpdater)
        {
            this.episodeUpdater = episodeUpdater;
        }

        public async Task<Episode> Create(EpisodeDataDto dto)
        {
            var episode = new Episode();
            return await episodeUpdater.Update(episode, dto);
        }
    }
}
