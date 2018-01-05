using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Repositories.Interfaces
{
    public interface ITagsRepository : ICrudRepository<Tag, TagCreatingModel, string>
    {
        Tag GetByLabel(string label);
    }
}