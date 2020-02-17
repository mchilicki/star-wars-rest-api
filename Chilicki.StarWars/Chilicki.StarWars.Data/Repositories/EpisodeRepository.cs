using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Repositories
{
    public class EpisodeRepository : BaseRepository<Episode>
    {
        public EpisodeRepository(DbContext context) : base(context)
        {
        }
    }
}
