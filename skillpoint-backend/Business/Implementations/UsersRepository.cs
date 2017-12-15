using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;

namespace Business.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public UsersRepository(IDatabaseContext database)
        {
            _databaseContext = database;
        }

        public User CreateUser(UserCreatingModel userModel, List<Tag> tagsList)
        {
            var user = Data.Domain.Entities.User.Create(userModel.Username, userModel.Password, userModel.Name, userModel.Email,
                userModel.Location, null);

            List<UserTag> userTags = new List<UserTag>();

            foreach (var tag in tagsList)
            {
                userTags.Add(new UserTag(user.Id, user, tag.Label, tag));
            }

            user.Update(user.Username, user.Password, user.Name, user.Email, user.Location, userTags);

            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
            return _databaseContext.Users.FirstOrDefault(u => u.Id == user.Id);
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            foreach (var user in _databaseContext.Users.ToList())
            {
                var user_tags = _databaseContext.Entry(user).Collection("TagsList");

                if (!user_tags.IsLoaded)
                {
                    user_tags.Load();
                  
                }

                foreach (var ut in user_tags.CurrentValue)
                {
                    var tags = _databaseContext.Entry(ut).Reference("Tag");

                    if (!tags.IsLoaded)
                    {
                        tags.Load();

                    }
                }

                users.Add(user);
                
            }

            return users;
        }

        public User GetUserById(Guid id)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.Id == id);

            var user_tags = _databaseContext.Entry(user).Collection("TagsList");

            if (!user_tags.IsLoaded)
            {
                user_tags.Load();

            }

            foreach (var ut in user_tags.CurrentValue)
            {
                var tags = _databaseContext.Entry(ut).Reference("Tag");

                if (!tags.IsLoaded)
                {
                    tags.Load();

                }
            }

            return user;
        }

        public void Update(User user)
        {
            _databaseContext.Users.Update(user);
            _databaseContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();
        }

        public void DeleteById(Guid id)
        {   
            _databaseContext.Users.Remove(GetUserById(id));
            _databaseContext.SaveChanges();
        }
    }
} 