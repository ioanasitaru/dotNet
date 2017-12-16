using System;
using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Services.Interfaces
{
    public interface IUsersService : ICrudService<UserDTO>
    {
        void Create(UserCreatingModel userModel, List<Tag> tagsList);
        void UpdateUser(UserCreatingModel userModel, Guid Id);
    }
}
