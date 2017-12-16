using System.Collections.Generic;
using Data.Domain.Entities;
using DTOs;

namespace Business.Repositories.Interfaces
{
    public interface ITagsRepository : ICrudRepository<Tag>
    {
        Tag GetByLabel(string label);
    }
}