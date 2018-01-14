using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Services.Implementations
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _repository;

        public TagsService(ITagsRepository repository) => _repository = repository;

        public void Create(TagCreatingModel tag) => _repository.Create(tag);

        public void Delete(string label) => _repository.Delete(label);

        public IEnumerable<TagDTO> GetAll() => _repository.GetAll().ToList().ConvertAll(t => new TagDTO(t)).ToList();

        public TagDTO GetById(string label)
        {

            var tag = _repository.GetById(label);

            if (tag == null)
            {
                return null;
            }

            return new TagDTO(tag);
        }

        public void Update(TagCreatingModel model, string label) => _repository.Update(model, label);

        public List<Tag> CreateOrGet(List<TagCreatingModel> tagsModels, string title, string description)
        {

            List<Tag> tags = new List<Tag>();

        
            tagsModels.AddRange(GenerateTags(title, description));
            

            foreach (var tag in tagsModels)
            {
                var dbTag = _repository.GetByLabel(tag.Label);
                if (dbTag == null)
                {
                    
                        tag.Verified = true;

                    _repository.Create(tag);
                    dbTag = _repository.GetByLabel(tag.Label);
                }


                tags.Add(dbTag);
            }

            return tags;
        }

        public List<EventDTO> GetEventsByTag(string label)
        {
            return _repository.GetEventsByTag(label).ConvertAll(e => new EventDTO(e)).ToList();
        }

        private List<TagCreatingModel> GenerateTags(string title, string description)
        {
            List<TagCreatingModel> generatedTags = new List<TagCreatingModel>();
            List<string> predefinedTags = PredefinedTags.Values;


            List<string> words = title.Split(" ").ToList();
            words.AddRange(description.Split(" ").ToList());

            foreach (var word in words)
            {
                if (predefinedTags.Contains(word.ToUpper()))
                {
                    generatedTags.Add(new TagCreatingModel(word, true));
                }
            }

            return generatedTags;
        }
    }
}