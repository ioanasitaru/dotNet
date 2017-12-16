using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IUsersRepository : ICrudRepository<User>
    {
        User Create(User user, List<Tag> tags);
        void Delete(User user);
    }
} 