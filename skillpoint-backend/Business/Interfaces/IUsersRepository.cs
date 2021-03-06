﻿using System;
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
        Task CreateAsync(UserCreatingModel model, UserManager<User> userManager);
        User GetByUsername(string username);
        void CreateRelations(User user, List<Tag> tags);
    }
} 