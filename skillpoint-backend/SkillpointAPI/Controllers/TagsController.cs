using System;
using System.Collections.Generic;
using Business.Services.Interfaces;
using Data.Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {

        private readonly ITagsService _service;

        public TagsController(ITagsService service)
        {
            this._service = service;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            return _service.GetAllTags();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public Tag GetTag([FromRoute] Guid id)
        {
            return _service.GetTagById(id);
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagDTO tagDto)
        {
            var tagLabel = tagDto.Label;
            if (_service.GetTagByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var tag = Tag.Create(tagLabel);
                _service.CreateTag(tag);
            }
            else
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var tag = _service.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false);
                _service.UpdateTag(tag);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] Guid id)
        {
            _service.DeleteTag(id);

        }
    }
}