using System;
using System.Collections.Generic;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using Data.Domain.Entities;

namespace Business.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Event Create(Event entity)
        {
            return _eventsRepository.CreateEvent(entity);
        }

        public void Update(Event entity)
        {
            _eventsRepository.UpdateEvent(entity);
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventsRepository.GetAllEvents();
        }

        public Event GetById(Guid id)
        {
            return _eventsRepository.GetEventById(id);
        }

        public void Delete(Guid id)
        {
            _eventsRepository.DeleteEvent(id);
        }
    }
}
