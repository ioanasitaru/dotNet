using System.Collections.Generic;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Services.Interfaces
{
    public interface IUsersService : ICrudService<User, UserCreatingModel, UserDTO>
    {
        void Create(UserCreatingModel userModel, List<Tag> tagsList);
    }
}
