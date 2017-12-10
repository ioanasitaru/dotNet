using System;
using System.Collections.Generic;
using Business.Interfaces;
using Business.Repositories.Interfaces;
using Data.Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITagsRepository _tagsRepository;

        public UsersController(IUsersRepository usersRepository, ITagsRepository tagsRepository)
        {
            _usersRepository = usersRepository;
            _tagsRepository = tagsRepository;
        }

        //GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User GetUser([FromRoute] Guid id)
        {
            return _usersRepository.GetUserById(id);
        }

        // POST: api/Users
        [HttpPost]
        public void PostUser([FromBody] UserDTO userDto)
        {
            var tagsList = _tagsRepository.TagsFromDTO(userDto.TagsList);
            var user = Data.Domain.Entities.User.Create(userDto.Username, userDto.Password, userDto.Name, userDto.Email,
                userDto.Location, tagsList);
            _usersRepository.CreateUser(user);
        }
        
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute] Guid id)
        {
            _usersRepository.DeleteById(id);
        }
    }
}