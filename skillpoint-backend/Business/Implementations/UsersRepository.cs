using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public void Create(UserCreatingModel user)
        {

            var dbUser = User.Create(user.Username, user.Password, user.Name, user.Email, user.Location, null);
            List<Tag> userTags = new List<Tag>();
            foreach (var tag in user.Tags)
            {
                userTags.Add(Tag.Create(tag.Label));
            }

            AddUser(dbUser,userTags);

            _databaseContext.SaveChanges();
        }


        private void AddUser(User user, List<Tag> tags)
        {
            _databaseContext.Database.OpenConnection();

            ITagsRepository _tagsRepository = new TagsRepository(_databaseContext);

            try
            {
                foreach (var tag in tags)
                {
                    if (_tagsRepository.GetById(tag.Label) != null)
                    {
                        var sql = String.Format("INSERT INTO dbo.Users VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                            user.Id, user.Email, user.Location, user.Name, user.Password, user.Username);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("INSERT INTO dbo.UserTag VALUES('{0}', '{1}')", user.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                    else
                    {
                        var sql = String.Format("INSERT INTO dbo.Users VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                            user.Id, user.Email, user.Location, user.Name, user.Password, user.Username);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("INSERT INTO dbo.Tags VALUES('{0}','{3}')", tag.Label, "null", "null",
                            tag.Verified);
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
                users.Add(user);
            }
            return users;
        }

        public User GetById(Guid id)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.Id == id);
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
            return user;
        }

        public void Update(UserCreatingModel userModel, Guid id)
        {
            var user = GetById(id);

            List<UserTag> userTags = new List<UserTag>();

            foreach (var tag in userModel.Tags)
            {
                userTags.Add(new UserTag(user.Id, user, tag.Label, Tag.Create(tag.Label)));
            }

            user.Update(userModel.Username, userModel.Password, userModel.Name, userModel.Email,
                userModel.Location, userTags);

            _databaseContext.Users.Update(user);
        }

        public void Delete(Guid id)
        {
            _databaseContext.Users.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }
    }
}