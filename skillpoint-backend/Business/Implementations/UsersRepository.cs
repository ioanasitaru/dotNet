using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using DTOs;


namespace Business.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public UsersRepository(IDatabaseContext database)
        {
            _databaseContext = database;
        }

        public User Create(UserCreatingModel user, List<Tag> tagsList)
        {
            var dbUser = User.Create(user.Username, user.Password, user.Name, user.Email, user.Location, null);
            List<UserTag> userTags = new List<UserTag>();
            foreach (var tag in tagsList)
            {
                userTags.Add(new UserTag(dbUser.Id, dbUser, tag.Label, tag));
            }
            dbUser.Update(user.Username, user.Password, user.Name, user.Email, user.Location, userTags);
            _databaseContext.Users.Add(dbUser);
            _databaseContext.SaveChanges();
            return _databaseContext.Users.FirstOrDefault(u => u.Id == dbUser.Id);
        }

        public User Create(UserCreatingModel userModel)
        {
            throw new NotImplementedException("Users require a tag list along the model");
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

        public void Update(UserDTO user, List<Tag> tags)
        {
            var dbUser = GetById(user.Id);
            var userTags = tags.ConvertAll(t => new UserTag(dbUser.Id, dbUser, t.Label, t)).ToList();
            dbUser.Update(user.Username, user.Password, user.Name, user.Email, user.Location, userTags);
            _databaseContext.Users.Update(dbUser);
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

        public void Update(UserDTO entity)
        {
            throw new NotImplementedException("Users also require a tag list");
        }
    }
}