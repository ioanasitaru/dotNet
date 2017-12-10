using System;
using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Data.Domain.Entities;
using Data.Persistence;

namespace Business.Repositories.Implementations
{
    public class TagsRepository : ITagsRepository
    {
        private IDatabaseContext _databaseContext;

        public void CreateTag(Tag tag)
        {
            _databaseContext.Tags.Add(tag);
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
