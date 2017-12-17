using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        Event CreateEvent(EventCreatingModel creatingModel, List<Tag> tags);

        IReadOnlyList<Event> GetAllEvents();

        Event GetEventById(Guid id);

        void UpdateEvent(EventCreatingModel eventCreatingModel, Guid id);

        void DeleteEvent(Guid id);
    }
}
