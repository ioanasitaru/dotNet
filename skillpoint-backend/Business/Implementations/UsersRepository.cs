using System;
using System.Collections.Generic;
using System.Linq;
using Business.Repositories.Interfaces;
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

        public void CreateUser(User user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            return _databaseContext.Users.Include(u => u.TagsList).ToList();
        }

        public User GetUserById(Guid id)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.Id == id);
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