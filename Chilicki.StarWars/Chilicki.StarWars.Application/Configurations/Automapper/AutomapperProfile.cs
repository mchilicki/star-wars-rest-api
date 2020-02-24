using AutoMapper;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Dtos.Friends;
using Chilicki.StarWars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Configurations.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BaseEntity, EntityDto>();
            CreateMap<BaseNamedEntity, NamedEntityDto>();
            CreateMap<Character, CharacterDto>()
                .ForMember(p => p.Episodes, p => p.MapFrom(e => e.CharacterEpisodes))
                .ForMember(p => p.Friends, p => p.MapFrom(e => e.CharacterFriends));
            CreateMap<Episode, EpisodeDto>();
            CreateMap<CharacterEpisode, EpisodeDto>()
                .IncludeMembers(p => p.Episode);
            CreateMap<Character, FriendDto>();
            CreateMap<CharacterFriend, FriendDto>()
                .IncludeMembers(p => p.Friend);
        }
    }
}
