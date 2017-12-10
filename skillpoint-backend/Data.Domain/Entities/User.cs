using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class User
    {
        private User()
        {
        }

        public Guid Id { get; private set; }

        [MaxLength(50)]
        public String Username { get; private set; }

        public String Password { get; private set; }

        [MaxLength(50)]
        public String Name { get; private set; }

        [EmailAddress]
        public String Email { get; private set; }

        public String Location { get; private set; }

        public List<Tag> TagsList { get; private set; }

        //public List<Event> EventsList { get; private set; }
        //        public List<Achivement> AchievementsList { get; private set; }

        public static User Create(string username, string password, string name, string email, string location, List<Tag> tagsList)
        {
            //add eventlist and achivementlist
            var instance = new User() {Id = Guid.NewGuid()};
            instance.Update(username, password, name, email, location, tagsList);
            return instance;
        }

        public void Update(string username, string password, string name, string email, string location,
            List<Tag> tagsList)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.Location = location;
            this.TagsList = tagsList;
        }
    }
}