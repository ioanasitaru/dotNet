using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class EventServiceTest : BaseIntegrationTest
    {
//        [TestMethod]
//        public void Given_EventService_When_CreatingAEvent_Then_ShouldCreateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                IEventsRepository eventRepository = new EventsRepository(sut);
//                IEventService eventService = new EventService(eventRepository);
//                var @event = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventService.Create(@event);
//                eventService.GetAll().Should().HaveCount(1);
//            });
//
//        }
//        [TestMethod]
//        public void Given_EventService_When_DeletingAEvent_Then_ShouldDeleteIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var eventService = new EventService(eventRepository);
//                var @event = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventService.Create(@event);
//                eventService.Delete(@event.Id);
//                eventService.GetAll().Should().HaveCount(0);
//            });
//        }
//        [TestMethod]
//        public void Given_EventService_When_GettingAllEvents_Then_ShouldGetAllEvents()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var eventService = new EventService(eventRepository);
//                var firstEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var secondEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var thirdEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventService.Create(firstEvent);
//                eventService.Create(secondEvent);
//                eventService.Create(thirdEvent);
//                eventService.GetAll().Should().HaveCount(3);
//            });
//        }
//        [TestMethod]
//        public void Given_EventService_When_GettingAEventById_Then_ShouldGetIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var eventService = new EventService(eventRepository);
//                var firstEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var secondEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                var thirdEvent = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventService.Create(firstEvent);
//                eventService.Create(secondEvent);
//                eventService.Create(thirdEvent);
//                eventService.GetById(thirdEvent.Id).Should().Be(thirdEvent);
//            });
//        }
//
//        [TestMethod]
//        public void Given_EventService_When_UpdatingAEvent_Then_ShouldUpdateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var eventRepository = new EventsRepository(sut);
//                var eventService = new EventService(eventRepository);
//                var @event = Event.Create("name", "description", new DateTime(), "location", new byte[4]);
//                eventService.Create(@event);
//                @event.Update("name2", "description", new DateTime(), "location", new byte[4]);
//                eventService.Update(@event);
//                eventService.GetById(@event.Id).Should().Be(@event);
//            });
//        }
    }
}
