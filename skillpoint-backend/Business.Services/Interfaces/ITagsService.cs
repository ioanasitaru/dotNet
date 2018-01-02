using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
 using DTOs;

namespace Business.Services.Interfaces
{
    public interface ITagsService : ICrudService<Tag, TagCreatingModel, TagDTO, string>
    {

        List<Tag> CreateOrGet(List<TagCreatingModel> tagModels);
    }
}
