using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IEventsRepository : ICrudRepository<Event, EventCreatingModel, Guid>
    {
        Task CreateAsync(EventCreatingModel model);
        void CreateRelations(Event @event, List<Tag> tags);
        Event GetByName(string name);
        Event IsInDb(EventCreatingModel model);
        void CreateRelations(Event @event, List<User> users);
    }
}
