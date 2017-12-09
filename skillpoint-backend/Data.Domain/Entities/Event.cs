using System;
using System.Collections.Generic;

namespace Data.Domain.Entities
{
    public class Event
    {
        private Event() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateAndTime { get; private set; }
        public string Location { get; private set; }
        public byte[] Image { get; private set; }

        public IEnumerable<Tag> Tags { get; private set; }

        public static Event Create(string name, string description, DateTime dateAndTime, string location, byte[] image)
        {
            var instance = new Event()
            {
                Id = Guid.NewGuid(),
                Tags = new List<Tag>()
            };
            instance.Update(name, description, dateAndTime, location, image);
            return instance;
        }

        public void Update(string name, string description, DateTime dateAndTime, string location, byte[] image)
        {
            Name = name;
            Description = description;
            DateAndTime = dateAndTime;
            Location = location;
            Image = image;
        }
    }
}
