using AirportWebApi.BL.Services;
using AirportWebApi.DAL;
using AirportWebApi.DAL.Models;
using AirportWebApi.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shared.Dtos;
using System;
using System.Collections.Generic;

namespace AirportWebApi.Tests
{
    [TestFixture]
    public class CrewServiceTest
    {
        //BaseService service;
        //AutoMapperConfiguration amc;
        //FakeUnitOfWork FUow;

        CrewDto crew;
        //AirportContext context;
        private Mock<IRepository<Crew>> ticketRepository;
        private Mock<IUow> mockUoW;
        private Mock<IMapper> mapper;
        private Mock<DbSet<Crew>> mockSet;
        private Mock<BaseService> service;

        [SetUp]
        public void Initialize()
        {
            mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<CrewDto>(It.IsAny<Crew>())).Returns(new CrewDto());
            ticketRepository = new Mock<IRepository<Crew>>();
            mockUoW = new Mock<IUow>();
            mockUoW.Setup(m => m.GetRepository<Crew>()).Returns(ticketRepository.Object);
            service = new Mock<BaseService>(mockUoW);
            crew = new CrewDto()
            {
                Id = 1,
                FlightAttendants = new List<FlightAttendant> { new FlightAttendant() { Id = 4, Birthday = new DateTime(), Name = "Monica", Surname = "Mancini" } },
                Pilot = new Pilot() { Id = 1, Name = "Karlos", Surname = "Gonsales", Birthday = new DateTime(), Experience = 4 }
            };

            mockSet = new Mock<DbSet<Crew>>();
            //mockSet.As<Crew>().Setup(m => m.Id).Returns(crew.Id);
            //mockSet.As<Crew>().Setup(m => m.Pilot).Returns(crew.Pilot);
            //mockSet.As<Crew>().Setup(m => m.FlightAttendants).Returns(crew.FlightAttendants);


        }

        [Test]
        [TestCase(4)]
        public void GetById_When_Calling_From_Generic_Service_Then_Receive_Entity_ById(int id)
        {

            var context = new Mock<AirportContext>();
            context.Setup(x => x.Crews).Returns(mockSet.Object);
            var rep = new CrewRepository(context.Object);
            mockUoW.Setup(x => x.GetRepository<Crew>()).Returns(rep);
            rep.Update(new Crew() { Id = 1 });
            var res = rep.GetById(1);
            //Assert
            Assert.AreEqual(res.Id, 1);
            //IMapper mapper;
            //amc = new AutoMapperConfiguration();
            //amc.Configure();
            //FUow = new FakeUnitOfWork(context);

            //var repos = FUow.GetRepository<Crew>();
            //var c = repos.GetById(4);
            //service = new BaseService(FUow);

            //mapper = amc.Configure().CreateMapper();

            //crew = new CrewDto()
            //{
            //    Id = 1,
            //    FlightAttendants = new List<FlightAttendant> { new FlightAttendant() { Id = 4, Birthday = new DateTime(), Name = "Monica", Surname = "Mancini" } },
            //    Pilot = new Pilot() { Id = 1, Name = "Karlos", Surname = "Gonsales", Birthday = new DateTime(), Experience = 4 }

            //};

            //var mapped = mapper.Map<CrewDto, Crew>(crew);

            //Crew dr = service.GetById<Crew>(mapped.Id);

            //Assert.AreEqual(dr.Id, id);

        }

    }



}


