using System;
using System.Collections.Generic;
using Business.Services.Interfaces;
using CreatingModels;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ITagsService _tagsService;

        public UsersController(IUsersService usersService, ITagsService tagsService)
        {
            _usersService = usersService;
            _tagsService = tagsService;
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
        public void PostUser([FromBody] UserCreatingModel userModel)
        {
            var tagsList = _tagsService.TagsFromCreatingModels(userModel.Tags);
            
            _usersService.Create(userModel, tagsList);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void UpdateUser([FromBody] UserCreatingModel userModel, [FromRoute] Guid id)
        {
            _usersService.UpdateUser(userModel, id);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute] Guid id)
        {
            _usersService.Delete(id);
        }
    }
}