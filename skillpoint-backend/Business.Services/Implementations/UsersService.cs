using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void Create(UserCreatingModel userModel)
        {
            
            _usersRepository.Create(userModel);
        }


        public void Update(UserCreatingModel userModel, Guid Id)
        {
            _usersRepository.Update(userModel, Id);
        }


        public IEnumerable<UserDTO> GetAll()
        {
            return _usersRepository.GetAll().ToList().ConvertAll(u => new UserDTO(u)).ToList();
        }

        public UserDTO GetById(Guid id)
        {
            return new UserDTO(_usersRepository.GetById(id));
        }

        public void Delete(Guid id)
        {
            _usersRepository.Delete(id);
        }

        public async Task CreateAsync(UserCreatingModel model, UserManager<User> userManager)
        {
           await _usersRepository.CreateAsync(model, userManager);
        }

        public User GetByUsername(string username) => _usersRepository.GetByUsername(username);
        public void CreateRelations(User user, List<Tag> tags)
        {
            _usersRepository.CreateRelations(user, tags);
        }
    }
}
