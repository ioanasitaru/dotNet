using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Repositories.Interfaces
{
    public interface IEventsRepository : ICrudRepository<Event, EventCreatingModel, EventDTO>
    {
    }
}
