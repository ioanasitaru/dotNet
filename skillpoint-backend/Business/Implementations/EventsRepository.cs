using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using Data.Domain.Entities;
using Data.Persistence;

namespace Business.Repositories.Implementations
{
    public class EventsRepository : IEventsRepository
    {
        private IDatabaseContext _databaseContext;

        public EventsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateEvent(Event myEvent)
        {
            _databaseContext.Events.Add(myEvent);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<Event> GetAllEvents()
        {
            return _databaseContext.Events.ToList();
        }

        public Event GetEventById(Guid id)
        {
            return _databaseContext.Events.First(e => e.Id == id);
        }

        public void UpdateEvent(Event myEvent)
        {
            _databaseContext.Events.Update(myEvent);
            _databaseContext.SaveChanges();
        }

        public void DeleteEvent(Guid id)
        {
            _databaseContext.Events.Remove(GetEventById(id));
            _databaseContext.SaveChanges();
        }
    }
}
