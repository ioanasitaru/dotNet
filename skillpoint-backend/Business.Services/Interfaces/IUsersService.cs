using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Interfaces
{
    public interface IUsersService : ICrudService<User, UserCreatingModel, UserDTO,Guid>
    {
        Task LoginUser(LogInCreatingModel model, UserManager<User> user);
    }
}
