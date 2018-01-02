using System;
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

        public TagDTO GetById(string label) => new TagDTO(_repository.GetById(label));

        public void Update(TagCreatingModel model, string label) => _repository.Update(model,label);

        public List<Tag> TagsFromCreatingModels(List<TagCreatingModel> tagsModels)
        {

            return tagsModels.Select(tagModel => _repository.GetById(tagModel.Label) ?? Tag.Create(tagModel.Label)).ToList();
        }

    }
}
