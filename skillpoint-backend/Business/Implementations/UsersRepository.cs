using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using DTOs;
using Microsoft.AspNetCore.Identity;

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

            var dbUser = User.Create(user.Username, user.Name, user.Email, user.Location, null);
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
                            user.Id, user.Email, user.Location, user.Name, user.PasswordHash, user.UserName);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("INSERT INTO dbo.UserTag VALUES('{0}', '{1}')", user.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                    else
                    {
                        var sql = String.Format("INSERT INTO dbo.AspNetUsers VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                           user.Id, user.AccessFailedCount, user.ConcurrencyStamp, user.DisplayName, user.Email, user.EmailConfirmed,  user.Location, user.LockoutEnabled, user.LockoutEnd, user.Name, user.NormalizedEmail, user.NormalizedUserName, user.PasswordHash, user.PhoneNumber, user.PhoneNumberConfirmed, user.SecurityStamp, user.TwoFactorEnabled, user.UserName);
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

            user.Update(userModel.Username, userModel.Name, userModel.Email,
                userModel.Location, userTags);

            _databaseContext.Users.Update(user);
        }

        public void Delete(Guid id)
        {
            _databaseContext.Users.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }

        public async Task LoginUser(LogInCreatingModel model, UserManager<User> userManager)
        {
            var user = User.Create(model.Username, model.Name, model.Email, model.Location, null);
            // Add the user to the Db with the choosen password
            await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, "RegisteredUser");
            _databaseContext.SaveChanges();
        }
    }
}