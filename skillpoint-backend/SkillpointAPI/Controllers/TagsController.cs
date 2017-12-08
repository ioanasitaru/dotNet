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
using Service;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsService service;

        public TagsController(ITagsService _service)
        {
            service = _service;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            return service.GetAllTags();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public Tag GetTag([FromRoute] Guid id)
        {
            return service.GetTagById(id);
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagDTO tagDto)
        {
            var tagLabel = tagDto.Label;
            var userId = tagDto.UserId;
            

            if (service.GetTagByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var user = new User();
                var tag = Tag.Create(tagLabel, user);
                service.CreateTag(tag);
               
            }
            else
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var user = new User();
                var tag = service.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false,user);
                service.UpdateTag(tag);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] Guid id)
        {
            service.DeleteTag(id);
        }
    }
}