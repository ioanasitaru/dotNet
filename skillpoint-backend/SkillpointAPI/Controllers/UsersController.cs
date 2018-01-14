using Business.Services.Interfaces;
using CreatingModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    [EnableCors("CorsPolicy")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ITagsService _tagsService;
        private readonly UserManager<User> _userManager;

        public UsersController(IUsersService usersService, ITagsService tagsService, UserManager<User> userManager, IEventService eventService)
        {
            _usersService = usersService;
            _tagsService = tagsService;
            _userManager = userManager;
        }

        //GET: api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _usersService.GetAll();
            if (users == null)
                return NotFound("There are no users");
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            var user = _usersService.GetById(id);
            if(user==null)
                return NotFound("There is no user with that id");
            return Ok(user);
        }

        //GET: api/Users/Events/5
        [Authorize]
        [HttpGet("/Events/{id}")]
        public IActionResult GetEventsByUserId([FromRoute] Guid id)
        {
            var events= _usersService.GetEventsByUserId(id);
            if (events == null)
                return NotFound("There are no events matching that tag");
            return Ok(events);
        }

        //GET: api/Users/PastEvent/5
        [Authorize]
        [HttpGet("/PastEvents/{id}")]
        public IActionResult GetPastEventsByUserId([FromRoute] Guid id)
        {
            var events = _usersService.GetEventsByUserId(id).FindAll(e => e.DateAndTime < DateTime.Now);
            if (events == null)
                return NotFound("There are no such events");
            return Ok(events);
        }

        //GET: api/Users/AllFutureEvents/5
        [Authorize]
        [HttpGet("/AllFutureEvents/{id}")]
        public IActionResult GetFutureEvesByUserIdAndTags([FromRoute] Guid id)
        {
            var events=_usersService.GetFutureEventsByUserIdAndTags(id);
            if (events == null)
                return NotFound("There are no such events");
            return Ok(events);

        }

        //GET: api/Users/AttendedFutureEvents/5
        [Authorize]
        [HttpGet("/AttendedFutureEvents/{id}")]
        public IActionResult GetFutureEventsByUserId([FromRoute] Guid id)
        {
            var events = _usersService.GetEventsByUserId(id).FindAll(e => e.DateAndTime > DateTime.Now);
            if (events == null)
                return NotFound("There are no such events");
            return Ok(events);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserCreatingModel userModel)
        {
            try
            {
                await _usersService.CreateAsync(userModel, _userManager);
                var tags = _tagsService.CreateOrGet(userModel.Tags, null, null);
                var user = _usersService.GetByUsername(userModel.Username);
                _usersService.CreateRelations(user, tags);
                return StatusCode((int)(HttpStatusCode.Created));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST: api/Users/attend/324
        [Authorize]
        [HttpPost("/Attend/{eventId}")]
        public IActionResult AttendEvent([FromBody] EventUser eventUser)
        {
            try
            {
                _usersService.CreateRelation(Guid.Parse(eventUser.UserId), eventUser.EventId);
                return StatusCode((int) (HttpStatusCode.Accepted));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT: api/Users/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] UserCreatingModel userModel, [FromRoute] Guid id)
        {
            UserCreatingModel aCreatingModel = new UserCreatingModel(userModel);



            try
            {
                
                _usersService.Update(aCreatingModel, id);
                _usersService.Update(userModel, id);

                return NoContent();
            }
            catch (Exception e)
            {

                return NoContent();
            }
        }



        // DELETE: api/Users/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                _usersService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
