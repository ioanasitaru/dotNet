using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CreatingModels;

namespace Data.Domain.Entities
{
    public class Tag
    {   
        [Key]
        public string Label
        {
            get ;
            private set ;
        }

        public List<UserTag> UsersList { get; private set; }
        public List<EventTag> EventsList { get; private set; }

        public bool Verified { get; private set; }

        private Tag()
        {
        }

        public static Tag Create(TagCreatingModel tagModel)
        {
            var instance = new Tag();
            instance.Update(tagModel.Label, false);
            return instance;
        }

        public void Update(string label, bool verified)
        {
            Label = label;
            Verified = verified;
        }

    }
}