using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
 using DTOs;

namespace Business.Services.Interfaces
{
    public interface ITagsService : ICrudService<Tag, TagCreatingModel, TagDTO>

    {
        TagDTO GetByLabel(string label);
        void Delete(string label);

        List<Tag> TagsFromCreatingModels(List<TagCreatingModel> tagModels);
    }
}
