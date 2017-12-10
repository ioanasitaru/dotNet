using System;
using System.Collections.Generic;
using System.Linq;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Data.Persistence;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEvents()
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

            _eventService.Save(@event);

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

            _eventService.Save(@event);

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