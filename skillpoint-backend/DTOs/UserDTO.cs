using System;
using System.Collections.Generic;
using System.Linq;
using CreatingModels;
using Data.Domain.Entities;

namespace DTOs
{
    public class UserDTO : UserCreatingModel
    {

        public Guid Id { get; set; }

        public List<TagDTO> Tags { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Email = user.Email;
            Location = user.Location;
            Tags = user.Tags.ConvertAll(ut => new TagDTO(ut)).ToList();
        }
    }
}
