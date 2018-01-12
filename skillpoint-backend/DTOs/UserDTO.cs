using System.Collections.Generic;
using System.Linq;
using CreatingModels;
using Data.Domain.Entities;

namespace DTOs
{
    public class UserDTO : UserCreatingModel
    {
        public string Id { get; set; }

        public new List<TagDTO> Tags { get; set; }

        public new List<EventDTO> Events { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.UserName;
            Password = user.PasswordHash;
            Name = user.Name;
            Email = user.Email;
            Location = user.Location;
            Tags = user.Tags?.ConvertAll(ut => new TagDTO(ut)).ToList();
            Events = user.Events?.ConvertAll(ue => new EventDTO(ue.Event)).ToList();
        }
    }
}
