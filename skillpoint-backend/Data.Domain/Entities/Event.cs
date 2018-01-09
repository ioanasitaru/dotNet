using System;
using System.Collections.Generic;
using CreatingModels;

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
        public string Image { get; private set; }

        public List<EventTag> Tags { get; private set; }

        public static Event Create(string name, string description, DateTime dateAndTime, string location, string image,List<EventTag> tagList)
        {
            var instance = new Event
            {
                Id = Guid.NewGuid()
            };
            instance.Update(name, description, dateAndTime, location, image,tagList);
            return instance;
        }

        public static Event Create(EventCreatingModel eventModel,List<EventTag> tagList)
        {
            var instance = new Event
            {
                Id = Guid.NewGuid()
            };
            instance.Update(eventModel.Name, eventModel.Description, eventModel.DateAndTime, eventModel.Location, eventModel.Image,tagList);
            return instance;
        }

        public void Update(string name, string description, DateTime dateAndTime, string location, string image,List<EventTag> tagList)
        {
            Name = name;
            Description = description;
            DateAndTime = dateAndTime;
            Location = location;
            Image = image;
            Tags = tagList;
        }
    }
}
