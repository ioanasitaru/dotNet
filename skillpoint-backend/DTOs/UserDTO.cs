using System;
using System.Collections.Generic;
using System.Linq;
using CreatingModels;
using Data.Domain.Entities;

namespace DTOs
{
    public class UserDTO : DTO<User>
    {

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Email = user.Email;
            Location = user.Location;
            Tags = user.TagsList.ConvertAll(ut => new TagDTO(ut)).ToList();
        }

        public String Username { get; set; }

        public String Password { get; set; }

        public String Name { get; set; }
       
        public String Email { get; set; }

        public String Location { get; set; }

        public List<TagDTO> Tags { get; set; }
    }
}
