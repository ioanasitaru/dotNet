using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CreatingModels;
using Microsoft.AspNetCore.Identity;

namespace Data.Domain.Entities
{
    public class User: IdentityUser
    {
        private User()
        {
        }

        [MaxLength(50)]
        public String DisplayName { get; private set; }


        [MaxLength(50)]
        public String Name { get; private set; }


        public String Location { get; private set; }

        public List<UserTag> Tags { get; private set; }

        public List<EventUser> Events { get; private set; }
        
        public static User Create(string username, string name, string email, string location,
            List<UserTag> tagsList, List<EventUser> events)
        {
            var instance = new User {Id = Guid.NewGuid().ToString()};
            instance.Update(username, name, email, location, tagsList, events);
            return instance;
        }

        public static User Create(UserCreatingModel userModel, List<UserTag> tagsList, List<EventUser> events)
        {
            //add eventlist and achivementlist
            var instance = new User { Id = Guid.NewGuid().ToString() };
            instance.Update(userModel.Username, userModel.Name, userModel.Email, userModel.Location, tagsList, events);
            return instance;
        }

        public void Update(string username, string name, string email, string location,
            List<UserTag> tagsList, List<EventUser> events)
        {
            Name = name;
            Email = email;
            Location = location;
            Tags = tagsList;
            Events = events;
            UserName = username;
        }
    }
}