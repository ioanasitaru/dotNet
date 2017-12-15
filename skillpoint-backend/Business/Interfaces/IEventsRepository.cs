using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        Event CreateEvent(Event myEvent);

        IReadOnlyList<Event> GetAllEvents();

        Event GetEventById(Guid id);

        void UpdateEvent(Event myEvent);

        void DeleteEvent(Guid id);
    }
}
