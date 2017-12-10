using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;

namespace Business
{
    public class TagsRepository : ITagsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public TagsRepository(IDatabaseContext databaseContext) => _databaseContext = databaseContext;

        public void CreateTag(Tag _tag)
        {
            _databaseContext.Tags.Add(_tag);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<Tag> GetAllTags() => _databaseContext.Tags.ToList();

        public Tag GetTagByLabel(string label) =>
            _databaseContext.Tags.First(t => t.Label.ToLower().Equals(label.ToLower()));

        public Tag GetTagById(Guid id) => _databaseContext.Tags.First(t => t.Id == id);

        public void UpdateTag(Tag tag)
        {
            _databaseContext.Tags.Update(tag);
            _databaseContext.SaveChanges();
        }

        public void DeleteTag(Guid id)
        {
            var tag = _databaseContext.Tags.FirstOrDefault(t => t.Id == id);
            _databaseContext.Tags.Remove(tag);
            _databaseContext.SaveChanges();
        }
    }
}
