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
            //            foreach (var tag in user.TagsList)
            //            {
            //                try
            //                {
            //                    _tagsRepository.DeleteTag(tag.Label);
            //                }
            //                catch (ArgumentNullException ex)
            //                {
            //                    continue;
            //                }
            //            }

            
            _usersRepository.Create(userModel, tagsList);
        }

        public User Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            _usersRepository.Update(user);
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
            return _usersRepository.GetAll().ToList().ConvertAll(u => new UserDTO(u)).ToList();
        }

        public UserDTO GetById(Guid id)
        {
            return new UserDTO(_usersRepository.GetById(id));
        }

        public void Delete(Guid id)
        {
            _usersRepository.DeleteById(id);
        }

        public User Create(UserDTO userDto, List<Tag> tagsList)
        {
            throw new NotImplementedException();
        }
    }
}
