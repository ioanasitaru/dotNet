using Data.Domain.Interfaces;
using System;
using Data.Domain.Entities;
using System.Collections.Generic;

namespace Service
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository repository;

        public TagsService(ITagsRepository _repository) => repository = _repository;

        public void CreateTag(Tag tag) => repository.CreateTag(tag);

        public void DeleteTag(Guid id) => repository.DeleteTag(id);

        public IReadOnlyList<Tag> GetAllTags() => repository.GetAllTags();

        public Tag GetTagById(Guid id) => repository.GetTagById(id);

        public Tag GetTagByLabel(string label) => repository.GetTagByLabel(label);

        public void UpdateTag(Tag tag) => repository.UpdateTag(tag);
    }
}
