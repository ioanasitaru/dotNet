using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
 using DTOs;

namespace Business.Services.Interfaces
{
    public interface ITagsService : ICrudService<Tag>

    {
        TagDTO GetTagByLabel(string label);

        List<Tag> TagsFromCreatingModels(List<TagCreatingModel> tagModels);
    }
}
