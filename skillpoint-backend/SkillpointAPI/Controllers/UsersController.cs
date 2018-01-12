using Business.Services.Interfaces;
using CreatingModels;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services.Implementations;
using Data.Domain.Entities;
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
        private readonly IEventService _eventService;

        public UsersController(IUsersService usersService, ITagsService tagsService, UserManager<User> userManager, IEventService eventService)
        {
            _usersService = usersService;
            _tagsService = tagsService;
            _userManager = userManager;
            _eventService = eventService;
        }

        //GET: api/Users
        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _usersService.GetAll();
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public UserDTO GetUser([FromRoute] Guid id)
        {
            return _usersService.GetById(id);
        }

        //GET: api/Users/Events/5
        [HttpGet("/Events/{id}")]
        public List<EventDTO> GetEventsByUserId([FromRoute] Guid id)
        {
            return _usersService.GetEventsByUserId(id);
        }

        //GET: api/Users/FutureEvents/5
        [HttpGet("/FutureEvents/{id}")]
        public List<EventDTO> GetFutureEventsByUserId([FromRoute] Guid id)
        {
            return _usersService.GetEventsByUserId(id).FindAll(e => e.DateAndTime > DateTime.Now);
        }

        // POST: api/Users
        [HttpPost]
        public async Task PostUser([FromBody] UserCreatingModel userModel)
        {
            await _usersService.CreateAsync(userModel, _userManager);
            var tags = _tagsService.CreateOrGet(userModel.Tags);
            var user = _usersService.GetByUsername(userModel.Username);
            _usersService.CreateRelations(user, tags);
        }


        // POST: api/Users/attend/324
        [HttpPost("/Attend/{eventId}")]
        public void AttendEvent(Guid userId, Guid eventId)
        {
            _usersService.CreateRelation(userId, eventId);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void UpdateUser([FromBody] UserCreatingModel userModel, [FromRoute] Guid id)
        {
            _usersService.Update(userModel, id);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute] Guid id)
        {
            _usersService.Delete(id);
        }
    }
}
