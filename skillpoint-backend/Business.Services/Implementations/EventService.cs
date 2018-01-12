using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void Create(EventCreatingModel model)
        {
            _eventsRepository.Create(model);
        }

        public void Update(EventCreatingModel model, Guid id)
        {
            _eventsRepository.Update(model,id);
        }

        public IEnumerable<EventDTO> GetAll() => _eventsRepository.GetAll().ToList().ConvertAll(e => new EventDTO(e));
        EventDTO ICrudService<Event, EventCreatingModel, EventDTO, Guid>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }


        public Event GetById(Guid id) => _eventsRepository.GetById(id);


        public void Delete(Guid id)
        {
            _eventsRepository.Delete(id);
        }

        public async Task CreateAsync(EventCreatingModel model)
        {
            await _eventsRepository.CreateAsync(model);
        }

        public void CreateRelations(Event @event, List<Tag> tags)
        {
             _eventsRepository.CreateRelations(@event, tags);
        }

        public void CreateRelations(Event @event, List<User> users)
        {
            _eventsRepository.CreateRelations(@event, users);
        }

        public Event GetByName(string name)
        {
            return _eventsRepository.GetByName(name);
        }

        public Event IsInDb(EventCreatingModel model)
        {
            return _eventsRepository.IsInDb(model);
        }
    }
}
