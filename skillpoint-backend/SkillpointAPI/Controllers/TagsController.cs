using System.Collections.Generic;
using Business.Services.Interfaces;
using CreatingModels;
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
        public IEnumerable<TagDTO> GetTags()
        {
            return _service.GetAll();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public TagDTO GetTag([FromRoute] string label)
        {
            return _service.GetByLabel(label);
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagCreatingModel tagModel)
        {
            var tagLabel = tagModel.Label;
            if (_service.GetByLabel(tagLabel) == null)
            {
                _service.Create(tagModel);
            }
            else
            {
                //momentan cream un user, doarece nu avem service-ul de user
                _service.Create(tagModel);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] string label)
        {
            _service.Delete(label);
        }
    }
}