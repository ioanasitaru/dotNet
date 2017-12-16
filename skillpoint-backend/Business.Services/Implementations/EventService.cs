using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public void Create(CreatingModel<Event> entity)
        {
            _eventsRepository.Create(entity);
        }

        public void Update(Event entity)
        {
            _eventsRepository.Update(entity);
        }

        public IEnumerable<DTO<Event>> GetAll()
        {
            return _eventsRepository.GetAll().ToList().ConvertAll(e => new EventDTO(e));
        }

        public DTO<Event> GetById(Guid id)
        {
            return new EventDTO(_eventsRepository.GetById(id));
        }

        public void Delete(Guid id)
        {
            _eventsRepository.Delete(id);
        }
    }
}
