using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace SkillpointAPI.DTOs
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
