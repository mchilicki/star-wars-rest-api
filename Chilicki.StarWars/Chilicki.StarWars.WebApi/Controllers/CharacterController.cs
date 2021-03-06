﻿using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Services;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.StarWars.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : CrudController
        <Character, CharacterDto, CharacterDataDto,
        CharacterFactory, CharacterUpdater, CharacterValidator>
    {
        public CharacterController(
            CrudService<Character, CharacterDto, CharacterDataDto, 
                CharacterFactory, CharacterUpdater, CharacterValidator> service) : base(service)
        {
        }
    }
}
