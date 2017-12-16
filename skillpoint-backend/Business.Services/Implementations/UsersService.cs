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

        public void Update(UserDTO user)
        {
            List<Tag> tags = new List<Tag>();
            _usersRepository.Update(user, tags);
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


        public void Create(UserCreatingModel entity)
        {
            throw new NotImplementedException("Users require a tag list as well");
        }
    }
}
