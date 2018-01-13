using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Business.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IEventsRepository _eventsRepository;

        public UsersRepository(IDatabaseContext database, IEventsRepository eventsRepository)
        {
            _databaseContext = database;
            _eventsRepository = eventsRepository;
        }

        public async Task CreateAsync(UserCreatingModel model, UserManager<User> userManager)
        {
            var user = User.Create(model.Username, model.Name, model.Email, model.Location, null, null);
            if (model.Password != model.ConfirmPassword)
                throw new ArgumentException("Passwords do not match!");
            // Add the user to the Db with the choosen password
            await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, "RegisteredUser");
            _databaseContext.SaveChanges();
        }

        public User GetByUsername(string username) =>
            _databaseContext.Users.FirstOrDefault(u => u.UserName.Equals(username));

        public void CreateRelations(User user, List<Tag> tags)
        {
            List<UserTag> userTags = tags.ConvertAll(t => new UserTag(user.Id, user, t.Label, t));
            foreach (var userTag in userTags)
            {
                //                _databaseContext.UserTag.Add(userTag);
                var sql = String.Format("INSERT INTO dbo.UserTag VALUES('{0}', '{1}')", user.Id, userTag.Tag.Label);
                _databaseContext.Database.ExecuteSqlCommand(sql);
            }
            _databaseContext.SaveChanges();
        }

        public void CreateRelation(Guid userId, Guid eventId)
        {
            var eventUser = new EventUser(eventId, _eventsRepository.GetById(eventId), userId.ToString(),
                GetById(userId));
            var userEvent = _databaseContext.EventUser.FirstOrDefault(e => e.Equals(eventUser));

            if (userEvent == null)
            {
                var sql = String.Format("INSERT INTO dbo.EventUser VALUES('{0}', '{1}')", eventId, userId);
                _databaseContext.Database.ExecuteSqlCommand(sql);
            }
            else
            {
                _databaseContext.EventUser.Remove(userEvent);
            }

            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<User> GetAll()
        {
            List<User> users = new List<User>();

            foreach (var user in _databaseContext.Users.ToList())
            {
                var userTags = _databaseContext.Entry(user).Collection("Tags");
                if (!userTags.IsLoaded)
                {
                    userTags.Load();
                }
                foreach (var ut in userTags.CurrentValue)
                {
                    var tags = _databaseContext.Entry(ut).Reference("Tag");
                    if (!tags.IsLoaded)
                    {
                        tags.Load();
                    }
                }

                var userEvents = _databaseContext.Entry(user).Collection("Events");
                if (!userEvents.IsLoaded)
                {
                    userEvents.Load();
                }
                foreach (var ue in userEvents.CurrentValue)
                {
                    var events = _databaseContext.Entry(ue).Reference("Event");
                    if (!events.IsLoaded)
                    {
                        events.Load();
                    }
                }

                users.Add(user);
            }
            return users;
        }

        public User GetById(Guid id)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.Id == id.ToString());

            var userTags = _databaseContext.Entry(user).Collection("Tags");
            if (!userTags.IsLoaded)
            {
                userTags.Load();
            }
            foreach (var ut in userTags.CurrentValue)
            {
                var tags = _databaseContext.Entry(ut).Reference("Tag");
                if (!tags.IsLoaded)
                {
                    tags.Load();
                }
            }

            var userEvents = _databaseContext.Entry(user).Collection("Events");
            if (!userEvents.IsLoaded)
            {
                userEvents.Load();
            }
            foreach (var ue in userEvents.CurrentValue)
            {
                var events = _databaseContext.Entry(ue).Reference("Event");
                if (!events.IsLoaded)
                {
                    events.Load();
                }
            }

            return user;
        }

        public void Update(UserCreatingModel userModel, Guid id)
        {
            var user = GetById(id);

            List<UserTag> userTags = new List<UserTag>();
            List<EventUser> eventUser = new List<EventUser>();

            foreach (var tag in userModel.Tags)
            {
                userTags.Add(new UserTag(user.Id, user, tag.Label, Tag.Create(tag.Label)));
            }

          

            user.Update(userModel.Username, userModel.Name, userModel.Email,
                userModel.Location, userTags, eventUser);

            _databaseContext.Users.Update(user);
        }

        public void Delete(Guid id)
        {
            _databaseContext.Users.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }

        public List<Event> GetEventsByUserId(Guid userId)
        {
            var user = GetById(userId);

            return user?.Events?.ConvertAll(ue => ue.Event).ToList();
        }

        public void Create(UserCreatingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}