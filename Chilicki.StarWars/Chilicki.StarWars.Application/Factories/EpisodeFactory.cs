using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Episode Create(EpisodeDataDto dto)
        {
            var episode = new Episode();
            return episodeUpdater.Update(episode, dto);
        }
    }
}
