using System;
using System.Collections.Generic;
using System.Linq;
using CreatingModels;
using Data.Domain.Entities;

namespace DTOs
{
    public class EventDTO : EventCreatingModel
    { 
        public Guid Id { get; set; }

        public new List<TagDTO> Tags { get; set; }

        public EventDTO(Event Event)
        {
            Id = Event.Id;
            Name = Event.Name;
            Description = Event.Description;
            DateAndTime = Event.DateAndTime;
            Location = Event.Location;
            Image = Event.Image;
            Tags = Event.Tags?.ConvertAll(et => new TagDTO(et)).ToList();
        }
    }
}
