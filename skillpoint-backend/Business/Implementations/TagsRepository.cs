using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using Data.Domain.Entities;
using Data.Persistence;

namespace Business.Repositories.Implementations
{
    public class TagsRepository : ITagsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public TagsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateTag(Tag tag)
        {
            _databaseContext.Tags.Add(tag);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<Tag> GetAllTags() => _databaseContext.Tags.ToList();

        public Tag GetTagByLabel(string label) =>
            _databaseContext.Tags.FirstOrDefault(t => t.Label.ToLower().Equals(label.ToLower()));

        public void UpdateTag(Tag tag)
        {
            _databaseContext.Tags.Update(tag);
            _databaseContext.SaveChanges();
        }

        public void DeleteTag(string label)
        {
            var tag = _databaseContext.Tags.FirstOrDefault(t => t.Label.Equals(label));
            _databaseContext.Tags.Remove(tag);
            _databaseContext.SaveChanges();
        }
    }
}
