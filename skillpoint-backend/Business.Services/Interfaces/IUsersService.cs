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
        Task CreateAsync(UserCreatingModel model, UserManager<User> userManager);
        User GetByUsername(string username);
        void CreateRelations(User user, List<Tag> tags);
        void CreateRelation(Guid userId, Guid eventId);
        List<EventDTO> GetEventsByUserId(Guid userId);
    }
}
