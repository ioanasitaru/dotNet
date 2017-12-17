using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

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

            user.Update(user.Username, user.Password, user.Name, user.Email, user.Location,userTags);

            AddUser(user, tagsList);
            _databaseContext.SaveChanges();
            return _databaseContext.Users.FirstOrDefault(u => u.Id == user.Id);
        }

        private void AddUser(User user, List<Tag> tags)
        {
            _databaseContext.Database.OpenConnection();

            ITagsRepository _tagsRepository = new TagsRepository(_databaseContext);

            try
            {
                foreach (var tag in tags)
                {
                    if (_tagsRepository.GetTagByLabel(tag.Label) != null)
                    {
                        var sql = String.Format("INSERT INTO dbo.Users VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", user.Id, user.Email, user.Location, user.Name, user.Password, user.Username);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("INSERT INTO dbo.UserTag VALUES('{0}', '{1}')", user.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                    else
                    {
                        var sql = String.Format("INSERT INTO dbo.Users VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", user.Id, user.Email, user.Location, user.Name, user.Password, user.Username);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("INSERT INTO dbo.Tags VALUES('{0}','{3}')", tag.Label, "null","null", tag.Verified);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("INSERT INTO dbo.UserTag VALUES('{0}', '{1}')", user.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                }
            }
            finally
            {
                _databaseContext.Database.CloseConnection();
            }
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

        public void Update(UserCreatingModel userModel, Guid id)
        {
            var user = GetUserById(id);

            List<UserTag> userTags = new List<UserTag>();

            foreach (var tag in userModel.Tags)
            {
                userTags.Add(new UserTag(user.Id, user, tag.Label, Tag.Create(tag)));
            }

            user.Update(userModel.Username, userModel.Password, userModel.Name, userModel.Email,
                userModel.Location, userTags);

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