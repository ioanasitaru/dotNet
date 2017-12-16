using System;
using Data.Domain.Entities;

namespace DTOs
{
    public class EventDTO : DTO<Event>
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }

        public EventDTO(Event Event)
        {
            Id = Event.Id;
            Name = Event.Name;
            Description = Event.Description;
            DateAndTime = Event.DateAndTime;
            Location = Event.Location;
            Image = Event.Image;
        }
    }
}
