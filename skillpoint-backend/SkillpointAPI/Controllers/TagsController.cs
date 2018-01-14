using System;
using System.Linq;
using System.Net;
using Business.Services.Interfaces;
using CreatingModels;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetTags()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: api/Tags
        [HttpGet("Verified")]
        public IActionResult GetVerifiedTags()
        {
            try
            {
                return Ok(_service.GetAll().ToList().FindAll(t => t.Verified));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: api/Tags/5
        [HttpGet("{label}")]
        public IActionResult GetTag([FromRoute] string label)
        {
            try
            {
                return Ok(_service.GetById(label));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: api/Tags/Events/5
        // [Authorize]
        [HttpGet("/EventsByTag/{label}")]
        public IActionResult GetEventsByTag([FromRoute] string label)
        {
            try
            {
                return Ok(_service.GetEventsByTag(label));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        // POST: api/Tags
        // [Authorize]
        [HttpPost]
        public IActionResult PostTag([FromBody] TagCreatingModel tagModel)
        {
            try
            {
                var tagLabel = tagModel.Label;

//            if (!GetTags().Any())
//            {
//                _service.Create(tagModel);
//            }

                if (_service.GetById(tagLabel) == null)
                    _service.Create(tagModel);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Tags/5
        // [Authorize]
        [HttpDelete("{label}")]
        public IActionResult DeleteTag([FromRoute] string label)
        {
            try
            {
                _service.Delete(label);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}