using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User CreateUser(UserCreatingModel user, List<Tag> tagsList);

        IReadOnlyList<User> GetAllUsers();

        User GetUserById(Guid id);

        void Update(UserCreatingModel user, Guid Id);

        void Delete(User user);

        void DeleteById(Guid id);
    }
} 