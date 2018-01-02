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

        //public List<Event> EventsList { get; private set; }
        //public List<Achivement> AchievementsList { get; private set; }

        public static User Create(string username, string name, string email, string location,
            List<UserTag> tagsList)
        {
            //TODO: add eventlist and achivementlist

            var instance = new User {Id = Guid.NewGuid().ToString()};
            instance.Update(username,  name, email, location, tagsList);
            return instance;
        }

        public static User Create(UserCreatingModel userModel, List<UserTag> tagsList)
        {
            //add eventlist and achivementlist
            var instance = new User { Id = Guid.NewGuid().ToString() };
            instance.Update(userModel.Username, userModel.Name, userModel.Email, userModel.Location, tagsList);
            return instance;
        }

        public void Update(string username, string name, string email, string location,
            List<UserTag> tagsList)
        {
            Name = name;
            Email = email;
            Location = location;
            Tags = tagsList;
            UserName = username;
        }
    }
}