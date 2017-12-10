using System;
using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Business.Repositories.Interfaces;
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

        public void CreateTag(Tag tag)
        {
            _databaseContext.Tags.Add(tag);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<Tag> GetAllTags() => _databaseContext.Tags.ToList();

        public Tag GetTagByLabel(string label) =>
            _databaseContext.Tags.FirstOrDefault(t => t.Label.ToLower().Equals(label.ToLower()));

        public Tag GetTagById(Guid id) => _databaseContext.Tags.FirstOrDefault(t => t.Id == id);

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

        public List<Tag> TagsFromDTO(List<TagDTO> tagsDtos)
        {
            List<Tag> tagsList = new List<Tag>();

            foreach (var tagDto in tagsDtos)
            {
                var tag = GetTagByLabel(tagDto.Label);

                if (tag == null)
                {
                    tag = Tag.Create(tagDto.Label);
                }

                tagsList.Add(tag);
            }

            return tagsList;
        }
    }
}
