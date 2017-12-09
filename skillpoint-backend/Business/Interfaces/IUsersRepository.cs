using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void CreateUser(User user);

        IReadOnlyList<User> GetAllUsers();

        User GetUserById(Guid id);

        void Update(User user);

        void Delete(User user);
    }
} 