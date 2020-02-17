using AutoMapper;
using Chilicki.StarWars.Application.Dtos.Episodes;
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
    public class EpisodeService
        : CrudService<Episode, EpisodeDto, EpisodeDataDto,
            EpisodeFactory, EpisodeUpdater, EpisodeValidator>
    {
        public EpisodeService(
            IMapper mapper, 
            IBaseRepository<Episode> repository, 
            IUnitOfWork unitOfWork, 
            EpisodeValidator validator, 
            EpisodeFactory factory, 
            EpisodeUpdater updater) : base(mapper, repository, unitOfWork, validator, factory, updater)
        {
        }
    }
}
