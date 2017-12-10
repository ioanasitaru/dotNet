﻿using System;
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
            this._databaseContext = database;
        }

        public void CreateUser(User user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            return _databaseContext.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            _databaseContext.Users.Update(user);
        }

        public void Delete(User user)
        {
            _databaseContext.Users.Remove(user);
        }

        public void DeleteById(Guid id)
        {
            var user = GetUserById(id);
            _databaseContext.Users.Remove(user);
        }

        public User GetUserByEmail(string email)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserByUsername(string username)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.Username == username);
        }
    }
} 