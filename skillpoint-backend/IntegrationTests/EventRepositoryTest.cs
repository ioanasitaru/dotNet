using System;
using Business.Repositories.Implementations;
using Data.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class EventRepositoryTest : BaseIntegrationTest
    {
//        [TestMethod]
//        public void Given_EventRepository_When_CreatingAnEvent_Then_ShouldCreateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var @event = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventRepository.Create(@event);
//                eventRepository.GetAll().Should().HaveCount(1);
//            });
//
//        }
//        [TestMethod]
//        public void Given_EventRepository_When_DeletingAEvent_Then_ShouldDeleteIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var @event = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventRepository.Create(@event);
//                eventRepository.DeleteEvent(@event.Id);
//                eventRepository.GetAll().Should().HaveCount(0);
//            });
//        }
//        [TestMethod]
//        public void Given_EventRepository_When_GettingAllEvents_Then_ShouldGetAllEvents()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var firstEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var secondEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var thirdEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventRepository.Create(firstEvent);
//                eventRepository.Create(secondEvent);
//                eventRepository.Create(thirdEvent);
//                eventRepository.GetAll().Should().HaveCount(3);
//            });
//        }
//        [TestMethod]
//        public void Given_EventRepository_When_GettingAEventById_Then_ShouldGetIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var firstEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var secondEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var thirdEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventRepository.Create(firstEvent);
//                eventRepository.Create(secondEvent);
//                eventRepository.Create(thirdEvent);
//                eventRepository.GetEventById(thirdEvent.Id).Should().Be(thirdEvent);
//            });
//        }
//
//        [TestMethod]
//        public void Given_EventRepository_When_UpdatingAEvent_Then_ShouldUpdateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var @event = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventRepository.Create(@event);
//                @event.Update("newname", @event.Description, @event.DateAndTime, @event.Location, @event.Image);
//                eventRepository.UpdateEvent(@event);
//                eventRepository.GetEventById(@event.Id).Should().Be(@event);
//            });
//        }
    }
}
