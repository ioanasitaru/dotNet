using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface ITagsService
    {
        void CreateTag(Tag tag);

        IReadOnlyList<Tag> GetAllTags();

        Tag GetTagByLabel(string label);

        Tag GetTagById(Guid id);

        void UpdateTag(Tag tag);

        void DeleteTag(Guid id);
    }
}