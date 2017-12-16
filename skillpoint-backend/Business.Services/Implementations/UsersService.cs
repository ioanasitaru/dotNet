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

        public void Create(UserCreatingModel userModel, List<Tag> tagsList)
        {
            
            _usersRepository.CreateUser(userModel, tagsList);
        }

        public void Create(UserCreatingModel entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserCreatingModel userModel, Guid Id)
        {
            _usersRepository.Update(userModel, Id);
        }

        public void Create(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _usersRepository.GetAllUsers().ToList().ConvertAll(u => new UserDTO(u)).ToList();
        }

        public UserDTO GetById(Guid id)
        {
            return new UserDTO(_usersRepository.GetUserById(id));
        }

        public void Delete(Guid id)
        {
            _usersRepository.DeleteById(id);
        }
    }
}
