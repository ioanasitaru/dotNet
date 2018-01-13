using System.Collections.Generic;
using System.Linq;
using Business.Services.Interfaces;
using CreatingModels;
using DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    [EnableCors("CorsPolicy")]
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

        // GET: api/Tags
        [HttpGet("Verified")]
        public IEnumerable<TagDTO> GetVerifiedTags()
        {
            return _service.GetAll().ToList().FindAll(t => t.Verified);
        }

        // GET: api/Tags/5
        [HttpGet("{label}")]
        public TagDTO GetTag([FromRoute] string label)
        {
            return _service.GetById(label);
        }

        // GET: api/Tags/Events/5
        [HttpGet("/EventsByTag/{label}")]
        public List<EventDTO> GetEventsByTag([FromRoute] string label)
        {
            return _service.GetEventsByTag(label);
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