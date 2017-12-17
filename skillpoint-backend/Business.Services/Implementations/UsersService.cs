using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

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

    }
}
