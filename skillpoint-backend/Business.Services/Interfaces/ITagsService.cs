using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Services.Interfaces
{
    public interface ITagsService
    {
        void CreateTag(Tag tag);

        IReadOnlyList<Tag> GetAllTags();

        Tag GetTagByLabel(string label);

        void UpdateTag(Tag tag);

        void DeleteTag(string label);

        List<Tag> TagsFromCreatingModels(List<TagCreatingModel> tagModels);
    }
}
