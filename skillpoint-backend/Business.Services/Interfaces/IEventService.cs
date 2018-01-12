using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;


namespace Business.Services.Interfaces
{
    public interface IEventService : ICrudService<Event, EventCreatingModel, EventDTO,Guid>
    {
        Task CreateAsync(EventCreatingModel model);
        void CreateRelations(Event @event, List<Tag> tags);
        Event GetByName(string name);
        Event IsInDb(EventCreatingModel model);
        void CreateRelations(Event @event, List<User> users);
        Event GetById(Guid id);
    }
}
