using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ITagsService _tagsService;

        public EventsController(IEventService eventService, ITagsService tagsService)
        {
            _eventService = eventService;
            _tagsService = tagsService;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<EventDTO> GetEvents()
        {
            return _eventService.GetAll();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public IActionResult GetEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = _eventService.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public IActionResult PutEvent([FromRoute] Guid id, [FromBody]EventCreatingModel @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventService.Update(@event,id);

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task PostEvent([FromBody] EventCreatingModel eventModel)
        { 
            await _eventService.CreateAsync(eventModel);
            var tags = _tagsService.CreateOrGet(eventModel.Tags);
            var @event = _eventService.GetByName(eventModel.Name);

            _eventService.CreateRelations(@event,tags);

        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = _eventService.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            _eventService.Delete(id);

            return Ok(@event);
        }
    }
}