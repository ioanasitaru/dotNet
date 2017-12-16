using System;
using System.Collections.Generic;
using Data.Domain.Entities;
using DTOs;

namespace Business.Repositories.Interfaces
{
    public interface IEventsRepository : ICrudRepository<Event>
    {
    }
}
