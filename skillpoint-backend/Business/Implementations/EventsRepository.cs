using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using DTOs;

namespace Business.Repositories.Implementations
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public EventsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Event Create(EventCreatingModel myEvent)
        {
            var @event = Event.Create(myEvent.Name, myEvent.Description, myEvent.DateAndTime, myEvent.Location, myEvent.Image);
            _databaseContext.Events.Add(@event);
            _databaseContext.SaveChanges();
            return GetById(@event.Id);
        }

        public IReadOnlyList<Event> GetAll()
        {
            return _databaseContext.Events.ToList();
        }

        public Event GetById(Guid id)
        {
            return _databaseContext.Events.First(e => e.Id == id);
        }

        public void Update(EventDTO myEvent)
        {
            var @event = GetById(myEvent.Id);
            @event.Update(myEvent.Name, myEvent.Description, myEvent.DateAndTime, myEvent.Location, myEvent.Image);
            _databaseContext.Events.Update(@event);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _databaseContext.Events.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }
    }
}
