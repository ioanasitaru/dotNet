using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    // + Perciun Adrian
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

        public static Tag Create(string label, bool verified = false)
        {
            var instance = new Tag();
            instance.Update(label, verified);
            return instance;
        }

        public void Update(string label, bool verified)
        {
            Label = label;
            Verified = verified;
        }
    }
}