using System.Collections.Generic;
using Business.Services.Interfaces;
using CreatingModels;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsService _service;

        public TagsController(ITagsService service)
        {
            _service = service;
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
            return _service.GetById(label);
        }


        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagCreatingModel tagModel)
        {
            var tagLabel = tagModel.Label;
            if (_service.GetById(tagLabel) == null)
                _service.Create(tagModel);
            else
                _service.Create(tagModel);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{label}")]
        public void DeleteTag([FromRoute] string label)
        {
            _service.Delete(label);
        }
    }
}