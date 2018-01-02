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
        public readonly IEventsRepository _eventsRepository;

        public EventService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public void Create(EventCreatingModel model)
        {
            _eventsRepository.Create(model);
        }

 

        public void Update(EventCreatingModel model, Guid id)
        {
            _eventsRepository.Update(model,id);
        }

        public IEnumerable<EventDTO> GetAll() => _eventsRepository.GetAll().ToList().ConvertAll(e => new EventDTO(e));
    

        public EventDTO GetById(Guid id) => new EventDTO(_eventsRepository.GetById(id));


        public void Delete(Guid id)
        {
            _eventsRepository.Delete(id);
        }
    }
}
