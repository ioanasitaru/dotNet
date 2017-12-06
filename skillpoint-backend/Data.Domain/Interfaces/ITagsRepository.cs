using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface ITagsRepository
    {
        void CreateTag(Tag tag);

        IReadOnlyList<Tag> GetAllTags();

        Tag GetTagByLabel(string label);

        Tag GetTagById(Guid id);

        void UpdateTag(Tag tag);

        void DeleteTag(Guid id);
    }
}