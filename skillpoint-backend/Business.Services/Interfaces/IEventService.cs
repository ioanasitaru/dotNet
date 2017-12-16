using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Services.Interfaces
{
    public interface IEventService : ICrudService<Event, EventCreatingModel, EventDTO>
    {

    }
}
