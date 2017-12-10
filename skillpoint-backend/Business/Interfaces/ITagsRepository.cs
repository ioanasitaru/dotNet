using System;
using System.Collections.Generic;
using Data.Domain.Entities;
using DTOs;

namespace Business.Interfaces
{
    public interface ITagsRepository
    {
        void CreateTag(Tag tag);

        IReadOnlyList<Tag> GetAllTags();

        Tag GetTagByLabel(string label);

        Tag GetTagById(Guid id);

        void UpdateTag(Tag tag);

        void DeleteTag(Guid id);

        List<Tag> TagsFromDTO(List<TagDTO> tagsDtos);
    }
}