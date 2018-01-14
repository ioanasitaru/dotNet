using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using CreatingModels;
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
        public IActionResult GetEvents()
        {
            try
            {
                return Ok(_eventService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest((e.Message));
            }
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public IActionResult GetEvent([FromRoute] Guid id)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GET: api/Events/Future
        [HttpGet("Future")]
        public IActionResult GetFutureEvents()
        {
            try
            {
                return Ok(_eventService.GetAll().ToList().FindAll(e => e.DateAndTime > DateTime.Now));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public IActionResult PutEvent([FromRoute] Guid id, [FromBody] EventCreatingModel @event)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _eventService.Update(@event, id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] EventCreatingModel eventModel)
        {
            try
            {
                await _eventService.CreateAsync(eventModel);
                var tags = _tagsService.CreateOrGet(eventModel.Tags, eventModel.Name, eventModel.Description);
                var @event = _eventService.IsInDb(eventModel);

                _eventService.CreateRelations(@event, tags);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("bulk")]
        public async Task<IActionResult> PostEvents([FromBody] List<EventCreatingModel> eventModels)
        {
            try
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
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent([FromRoute] Guid id)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}