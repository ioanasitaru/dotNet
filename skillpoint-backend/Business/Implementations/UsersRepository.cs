using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
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

        public User Create(User user, List<Tag> tagsList)
        {
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

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> GetAll()
        {
            List<User> users = new List<User>();

            foreach (var user in _databaseContext.Users.ToList())
            {
                var userTags = _databaseContext.Entry(user).Collection("TagsList");
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
                users.Add(user);
            }
            return users;
        }

        public User GetById(Guid id)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.Id == id);
            var userTags = _databaseContext.Entry(user).Collection("TagsList");
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

        public void Delete(Guid id)
        {
            _databaseContext.Users.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }
    }
}