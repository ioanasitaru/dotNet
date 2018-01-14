using System;
using System.Collections.Generic;

namespace CreatingModels
{
    public class UserCreatingModel
    {
        public String Username { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Location { get; set; }
        
        public List<TagCreatingModel> Tags { get; set; }

        public List<EventCreatingModel> Events { get; set; }

        public UserCreatingModel()
        {
            
        }

        // copy constructor without tags :>
        public UserCreatingModel(UserCreatingModel anotherCreatingModel)
        {
            this.Tags = new List<TagCreatingModel>();
            this.Username = anotherCreatingModel.Username;
            this.Password = anotherCreatingModel.Password;
            this.ConfirmPassword = anotherCreatingModel.ConfirmPassword;
            this.Email = anotherCreatingModel.Email;
            this.Location = anotherCreatingModel.Location;
            this.Name = anotherCreatingModel.Name;

            this.Events = new List<EventCreatingModel>();
            Events.AddRange(anotherCreatingModel.Events);
        }
    }
}
