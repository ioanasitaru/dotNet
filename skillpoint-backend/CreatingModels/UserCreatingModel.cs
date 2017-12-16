using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace CreatingModels
{
    public class UserCreatingModel : CreatingModel<User>
    {
        public String Username { get; set; }

        public String Password { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Location { get; set; }

        public List<TagCreatingModel> Tags { get; set; }
    }
}
