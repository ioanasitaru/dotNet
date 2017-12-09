using System;
using System.Collections.Generic;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Data.Domain.Entities;
using SkillpointAPI.DTOs;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsRepository _repository;

        public TagsController(ITagsRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            return _repository.GetAllTags();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public Tag GetTag([FromRoute] Guid id)
        {
            return _repository.GetTagById(id);
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagDTO tagDto)
        {
            var tagLabel = tagDto.Label;
            var userId = tagDto.UserId;
            

            if (_repository.GetTagByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem repository-ul de user
                var user = new User();
                var tag = Tag.Create(tagLabel, user);
                _repository.CreateTag(tag);
               
            }
            else
            {
                //momentan cream un user, doarece nu avem repository-ul de user
                var user = new User();
                var tag = _repository.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false,user);
                _repository.UpdateTag(tag);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] Guid id)
        {
            _repository.DeleteTag(id);
        }
    }
}