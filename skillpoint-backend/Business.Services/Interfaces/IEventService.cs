using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Services.Interfaces
{
    public interface IEventService : ICrudService<Event>
    {
        void Create(EventCreatingModel eventCreatingModel, List<Tag> tags);

    }
}
