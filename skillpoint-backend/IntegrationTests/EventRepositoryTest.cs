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
//                eventRepository.CreateEvent(@event);
//                eventRepository.GetAllEvents().Should().HaveCount(1);
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
//                eventRepository.CreateEvent(@event);
//                eventRepository.DeleteEvent(@event.Id);
//                eventRepository.GetAllEvents().Should().HaveCount(0);
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
//                eventRepository.CreateEvent(firstEvent);
//                eventRepository.CreateEvent(secondEvent);
//                eventRepository.CreateEvent(thirdEvent);
//                eventRepository.GetAllEvents().Should().HaveCount(3);
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
//                eventRepository.CreateEvent(firstEvent);
//                eventRepository.CreateEvent(secondEvent);
//                eventRepository.CreateEvent(thirdEvent);
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
//                eventRepository.CreateEvent(@event);
//                @event.Update("newname", @event.Description, @event.DateAndTime, @event.Location, @event.Image);
//                eventRepository.UpdateEvent(@event);
//                eventRepository.GetEventById(@event.Id).Should().Be(@event);
//            });
//        }
    }
}
