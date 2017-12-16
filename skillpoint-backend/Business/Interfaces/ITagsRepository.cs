using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Repositories.Interfaces
{
    public interface ITagsRepository : ICrudRepository<Tag, TagCreatingModel, TagDTO>
    {
        Tag GetByLabel(string label);
        void Delete(string label);
    }
}