using System;
using System.Collections.Generic;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using Data.Domain.Entities;

namespace Business.Services.Implementations
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _repository;

        public TagsService(ITagsRepository repository) => _repository = repository;

        public void CreateTag(Tag tag) => _repository.CreateTag(tag);

        public void DeleteTag(Guid id) => _repository.DeleteTag(id);

        public IReadOnlyList<Tag> GetAllTags() => _repository.GetAllTags();

        public Tag GetTagById(Guid id) => _repository.GetTagById(id);

        public Tag GetTagByLabel(string label) => _repository.GetTagByLabel(label);

        public void UpdateTag(Tag tag) => _repository.UpdateTag(tag);
    }
}
