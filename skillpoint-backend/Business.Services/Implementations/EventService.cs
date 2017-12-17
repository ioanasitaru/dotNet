using System;
using System.Collections.Generic;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Services.Implementations
{
    public class EventService : IEventService
    {
        public readonly IEventsRepository _eventsRepository;

        public EventService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }


        public void Create(EventCreatingModel eventCreatingModel, List<Tag> tags)
        {
            _eventsRepository.CreateEvent(eventCreatingModel, tags);
        }


        public void Create(Event entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Event entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Event GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
