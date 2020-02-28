using AutoMapper;
using Chilicki.StarWars.Application.Configurations.Automapper;
using Chilicki.StarWars.Application.Dtos.Characters;
using Chilicki.StarWars.Application.Dtos.Episodes;
using Chilicki.StarWars.Application.Factories;
using Chilicki.StarWars.Application.Factories.Paging;
using Chilicki.StarWars.Application.Services;
using Chilicki.StarWars.Application.Tests.Configuration.DependencyInjection;
using Chilicki.StarWars.Application.Updaters;
using Chilicki.StarWars.Application.Validators;
using Chilicki.StarWars.Data.Databases.UnitOfWorks;
using Chilicki.StarWars.Data.Entities;
using Chilicki.StarWars.Data.Helpers.Exceptions;
using Chilicki.StarWars.Data.Helpers.Paging;
using Chilicki.StarWars.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Chilicki.StarWars.Application.Tests
{
    public class EpisodeServiceTests : IDisposable
    {
        private readonly IMapper mapper;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly Mock<IBaseRepository<Episode>> repository;
        private readonly EpisodeValidator validator;
        private readonly EpisodeFactory factory;
        private readonly EpisodeUpdater updater;
        private readonly PageFactory<EpisodeDto> pageFactory;
        CrudService
            <Episode, EpisodeDto, EpisodeDataDto,
            EpisodeFactory, EpisodeUpdater, EpisodeValidator> service;
        IServiceProvider serviceProvider;

        IEnumerable<Episode> repositoryEpisodes = new List<Episode>()
        {
            new Episode(){ Id = Guid.NewGuid(), Name = "Episode 1" },
            new Episode(){ Id = Guid.NewGuid(), Name = "Episode 2" },
            new Episode(){ Id = Guid.NewGuid(), Name = "Episode 3" },
            new Episode(){ Id = Guid.NewGuid(), Name = "Episode 4" },
            new Episode(){ Id = Guid.NewGuid(), Name = "Episode 5" },
            new Episode(){ Id = Guid.NewGuid(), Name = "Episode 6" },
        };

        public EpisodeServiceTests()
        {
            var services = new ServiceCollection();
            new TestDependencyInjection().Register(services, configuration: null);
            serviceProvider = services.BuildServiceProvider();
            mapper = serviceProvider.GetRequiredService<IMapper>();
            unitOfWork = new Mock<IUnitOfWork>();
            repository = new Mock<IBaseRepository<Episode>>();
            repository
                .Setup(p => p.GetAllAsync())
                .Returns(Task.FromResult(repositoryEpisodes));
            repository
                .Setup(p => p.GetPageAsync(It.Is<Pager>(e => e.PageSize == 3)))
                .Returns(Task.FromResult(repositoryEpisodes.Take(3)));
            repository
                .Setup(p => p.GetPageAsync(It.Is<Pager>(e => e.PageSize == 2)))
                .Returns(Task.FromResult(repositoryEpisodes.Take(2)));
            repository
                .Setup(p => p.FindAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(repositoryEpisodes.First()));
            repository
                .Setup(p => p.AddAsync(It.IsAny<Episode>()))
                .Returns(Task.FromResult(repositoryEpisodes.First()));
            validator = new EpisodeValidator(new NullValidator(), new NameValidator());
            pageFactory = new PageFactory<EpisodeDto>();
            updater = new EpisodeUpdater();
            factory = new EpisodeFactory(updater);
            service = new CrudService<Episode, EpisodeDto, EpisodeDataDto,
                EpisodeFactory, EpisodeUpdater, EpisodeValidator>(
                mapper, unitOfWork.Object, validator, factory, updater, repository.Object, pageFactory);
        }

        public void Dispose()
        {
            
        }

        [Fact]
        public async void TestGetAll()
        {
            var entities = await service.GetAll();
            Assert.NotNull(entities);
            Assert.True(entities.Count() == repositoryEpisodes.Count());
            Assert.Equal(entities.First().Name, repositoryEpisodes.First().Name);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public async void TestGetPage(int? currentPage, int? pageSize)
        {
            var page = await service.GetPage(new Pager(currentPage, pageSize));
            Assert.NotNull(page);
            Assert.True(page.Items.Count() == pageSize);
            Assert.Equal(page.Items.First().Name, repositoryEpisodes.First().Name);
        }
        
        [Fact]
        public async void TestFind()
        {
            var entities = await service.GetAll();
            var entity = await service.Find(entities.First().Id);
            Assert.NotNull(entity);
            Assert.Equal(entity.Id, entities.First().Id);
            Assert.Equal(entity.Name, entities.First().Name);
        }

        [Fact]
        public async void TestCorrectUpdate()
        {
            var entites = await service.GetAll();
            var dataDto = new EpisodeDataDto()
            {
                Name = "Updated Episode",
            };
            await service.Update(entites.First().Id, dataDto);
        }

        [Fact]
        public async void TestUpdateWithWrongId()
        {
            repository.Setup(p => p.FindAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult((Episode)null));
            var dataDto = new EpisodeDataDto()
            {
                Name = "Updated Episode",
            };
            await Assert.ThrowsAsync<NotFoundException>(
                async () =>
                await service.Update(Guid.NewGuid(), dataDto)
            );
        }

        [Fact]
        public async void TestUpdateWithNull()
        {
            var entites = await service.GetAll();
            EpisodeDataDto dataDto = null;
            await Assert.ThrowsAsync<BadRequestException>(
                async ()  => 
                await service.Update(entites.First().Id, dataDto)
            );            
        }

        [Fact]
        public async void TestUpdateWithNullName()
        {
            var entites = await service.GetAll();
            EpisodeDataDto dataDto = new EpisodeDataDto()
            {
                Name = null,
            };
            await Assert.ThrowsAsync<BadRequestException>(
                async () =>
                await service.Update(entites.First().Id, dataDto)
            );
        }

        [Fact]
        public async void TestDelete()
        {
            var entites = await service.GetAll();
            await service.Delete(entites.First().Id);
        }
    }
}
