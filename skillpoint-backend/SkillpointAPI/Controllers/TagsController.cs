using System;
using System.Collections.Generic;
using Business.Interfaces;
using Data.Domain.Entities;
<<<<<<< HEAD
using DTOs;
using Microsoft.AspNetCore.Mvc;
=======
using Data.Domain.Interfaces;
using Data.Persistence;
using SkillpointAPI.DTOs;
using Service;
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
<<<<<<< HEAD
        private readonly ITagsRepository _repository;

        public TagsController(ITagsRepository repository)
        {
            _repository = repository;
=======
        private readonly ITagsService service;

        public TagsController(ITagsService _service)
        {
            service = _service;
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
<<<<<<< HEAD
            return _repository.GetAllTags();
=======
            return service.GetAllTags();
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public Tag GetTag([FromRoute] Guid id)
        {
<<<<<<< HEAD
            return _repository.GetTagById(id);
=======
            return service.GetTagById(id);
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagDTO tagDto)
        {
            var tagLabel = tagDto.Label;
            

<<<<<<< HEAD
            if (_repository.GetTagByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem repository-ul de user
                var user = Data.Domain.Entities.User.Create();
                var tag = Tag.Create(tagLabel);
                _repository.CreateTag(tag);
=======
            if (service.GetTagByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var user = new User();
                var tag = Tag.Create(tagLabel, user);
                service.CreateTag(tag);
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
               
            }
            else
            {
<<<<<<< HEAD
                //momentan cream un user, doarece nu avem repository-ul de user
                var user = Data.Domain.Entities.User.Create();
                var tag = _repository.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false);
                _repository.UpdateTag(tag);
=======
                //momentan cream un user, doarece nu avem service-ul de user
                var user = new User();
                var tag = service.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false,user);
                service.UpdateTag(tag);
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] Guid id)
        {
<<<<<<< HEAD
            _repository.DeleteTag(id);
=======
            service.DeleteTag(id);
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
        }
    }
}