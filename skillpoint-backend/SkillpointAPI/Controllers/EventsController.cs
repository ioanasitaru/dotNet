using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using CreatingModels;
using DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    [EnableCors("CorsPolicy")]
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

        //GET: api/Events/Future
        [HttpGet("Future")]
        public IEnumerable<EventDTO> GetFutureEvents()
        {
            return _eventService.GetAll().ToList().FindAll(e => e.DateAndTime > DateTime.Now);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public IActionResult PutEvent([FromRoute] Guid id, [FromBody] EventCreatingModel @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventService.Update(@event, id);

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task PostEvent([FromBody] EventCreatingModel eventModel)
        {
            await _eventService.CreateAsync(eventModel);
            var tags = _tagsService.CreateOrGet(eventModel.Tags, eventModel.Name, eventModel.Description);
            var @event = _eventService.IsInDb(eventModel);

            _eventService.CreateRelations(@event, tags);

        }

        [HttpDelete]
        public IActionResult DeleteAll()
        {

            var events = _eventService.GetAll();
            foreach (var _event in events)
            {
                _eventService.Delete(_event.Id);
            }

            return Ok();

        }

        [HttpPost]
        [Route("bulk")]
        public async Task PostEvents([FromBody] List<EventCreatingModel> eventModels)
        {
            System.Diagnostics.Debug.WriteLine(eventModels);
            
            foreach (var _event in eventModels)
            {
                var dbEvent = _eventService.IsInDb(_event);

                if (dbEvent == null)
                {
                    await _eventService.CreateAsync(_event);
                    dbEvent = _eventService.IsInDb(_event);
                }

                var tags = _tagsService.CreateOrGet(_event.Tags, _event.Name, _event.Description);
                _eventService.CreateRelations(dbEvent, tags);

            }

        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent([FromRoute] Guid id)
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