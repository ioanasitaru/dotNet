using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Repositories.Interfaces
{
    public interface IUsersRepository : ICrudRepository<User, UserCreatingModel, Guid>
    {
        Task LoginUser(LogInCreatingModel model, UserManager<User> userManager);
    }
} 