using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using DTOs;

namespace Business.Repositories.Implementations
{
    public class TagsRepository : ITagsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public TagsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Tag Create(TagCreatingModel tagModel)
        {
            var tag = Tag.Create(tagModel.Label);
            _databaseContext.Tags.Add(tag);
            _databaseContext.SaveChanges();
            return GetByLabel(tag.Label);
        }

        public IReadOnlyList<Tag> GetAll() => _databaseContext.Tags.ToList();

        public Tag GetByLabel(string label) =>
            _databaseContext.Tags.FirstOrDefault(t => t.Label.ToLower().Equals(label.ToLower()));

        public void Update(TagDTO tag)
        {
            var dbTag = GetByLabel(tag.Label);
            dbTag.Update(tag.Label, tag.Verified);
            _databaseContext.Tags.Update(dbTag);
            _databaseContext.SaveChanges();
        }

        public void Delete(string label)
        {
            var tag = _databaseContext.Tags.FirstOrDefault(t => t.Label.Equals(label));
            _databaseContext.Tags.Remove(tag);
            _databaseContext.SaveChanges();
        }

        public Tag GetById(Guid id)
        {
            throw new NotImplementedException("Tags do not have Guids");
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException("Tags do not have Guids");
        }
    }
}
