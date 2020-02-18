using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Data.Entities
{
    public class CharacterFriend
    {
        public Guid CharacterId { get; set; }
        public Guid FriendId { get; set; }
        public virtual Character Character { get; set; }
        public virtual Character Friend { get; set; }
    }
}
