using Chilicki.StarWars.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Repositories
{
    public class CharacterRepository : BaseRepository<Character>
    {
        public CharacterRepository(DbContext context) : base(context)
        {
        }
    }
}
