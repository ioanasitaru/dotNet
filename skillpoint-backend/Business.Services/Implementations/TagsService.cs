using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Services.Implementations
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _repository;

        public TagsService(ITagsRepository repository) => _repository = repository;

        public void CreateTag(Tag tag) => _repository.CreateTag(tag);

        public void DeleteTag(string label) => _repository.DeleteTag(label);

        public IReadOnlyList<Tag> GetAllTags() => _repository.GetAllTags();

        public Tag GetTagByLabel(string label) => _repository.GetTagByLabel(label);

        public void UpdateTag(Tag tag) => _repository.UpdateTag(tag);

        public List<Tag> TagsFromCreatingModels(List<TagCreatingModel> tagsModels)
        {
            return tagsModels.Select(tagModel => GetTagByLabel(tagModel.Label) ?? Tag.Create(tagModel)).ToList();
        }
    }
}
