using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Data.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using SkillpointAPI.DTOs;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsRepository repository;

        public TagsController(ITagsRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            return repository.GetAllTags();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public Tag GetTag([FromRoute] Guid id)
        {
            return repository.GetTagById(id);
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagDTO tagDto)
        {
            var tagLabel = tagDto.Label;
            var userId = tagDto.UserId;
            

            if (repository.GetTagByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem repository-ul de user
                var user = new User();
                var tag = Tag.Create(tagLabel, user);
                repository.CreateTag(tag);
               
            }
            else
            {
                //momentan cream un user, doarece nu avem repository-ul de user
                var user = new User();
                var tag = repository.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false,user);
                repository.UpdateTag(tag);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] Guid id)
        {
            repository.DeleteTag(id);
        }
    }
}