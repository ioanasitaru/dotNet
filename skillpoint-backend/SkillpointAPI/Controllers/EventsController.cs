using System;
using System.Collections.Generic;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Data.Domain.Entities;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return eventService.GetAll();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public IActionResult GetEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = eventService.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public IActionResult PutEvent([FromRoute] Guid id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            eventService.Save(@event);

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public IActionResult PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            eventService.Save(@event);

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = eventService.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            eventService.Delete(id);

            return Ok(@event);
        }
    }
}