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
        private readonly ITagsRepository _tagsRepository;

        public UsersService(IUsersRepository usersRepository, ITagsRepository tagsRepository)
        {
            _usersRepository = usersRepository;
            _tagsRepository = tagsRepository;
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

        public void CreateRelation(Guid userId, Guid eventId)
        {
            _usersRepository.CreateRelation(userId, eventId);
        }

        public List<EventDTO> GetEventsByUserId(Guid userId)
        {
            return _usersRepository.GetEventsByUserId(userId).ConvertAll(e => new EventDTO(e)).ToList();
        }

        public List<EventDTO> GetFutureEventsByUserIdAndTags(Guid id)
        {
            List<EventDTO> eventList = new List<EventDTO>();

            var user = GetById(id);

            foreach (var tag in user.Tags)
            {
                var events = _tagsRepository.GetEventsByTag(tag.Label).FindAll(e => e.DateAndTime > DateTime.Now);
                eventList.AddRange(events.ConvertAll(e => new EventDTO(e)));
            }

            return eventList;
        }
    }
}
