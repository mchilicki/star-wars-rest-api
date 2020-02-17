using AutoMapper;
using Chilicki.StarWars.Application.Dtos;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.StarWars.Application.Services
{
    public class CharacterService
        : CrudService<Character, CharacterDto, CharacterDataDto, 
            CharacterFactory, CharacterUpdater, CharacterValidator>
    {
        public CharacterService(
            IMapper mapper, 
            IBaseRepository<Character> repository, 
            IUnitOfWork unitOfWork, 
            CharacterValidator validator, 
            CharacterFactory factory, 
            CharacterUpdater updater) 
            : base(mapper, repository, unitOfWork, validator, factory, updater)
        {
        }
    }
}
