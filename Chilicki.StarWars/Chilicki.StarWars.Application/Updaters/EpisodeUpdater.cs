using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Updaters
{
    public class EpisodeUpdater : IUpdater<Episode, EpisodeDataDto>
    {
        public Episode Update(Episode entity, EpisodeDataDto dto)
        {
            entity.Name = dto.Name;
            return entity;
        }
    }
}
