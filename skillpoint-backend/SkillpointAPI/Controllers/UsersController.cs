using Business.Services.Interfaces;
using CreatingModels;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public UsersController(IUsersService usersService, ITagsService tagsService, UserManager<User> userManager)
        {
            _usersService = usersService;
            _tagsService = tagsService;
            _userManager = userManager;
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

        // POST: api/Users
        [HttpPost]
        public async Task PostUser([FromBody] UserCreatingModel userModel)
        {
            await _usersService.CreateAsync(userModel, _userManager);
            var tags = _tagsService.CreateOrGet(userModel.Tags);
            var user = _usersService.GetByUsername(userModel.Username);
            _usersService.CreateRelations(user, tags);
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
