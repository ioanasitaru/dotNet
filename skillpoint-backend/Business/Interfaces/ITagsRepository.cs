using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface ITagsRepository : ICrudRepository<Tag, TagCreatingModel, string>
    {
        Tag GetByLabel(string label);
        List<Event> GetEventsByTag(string label);
    }
}