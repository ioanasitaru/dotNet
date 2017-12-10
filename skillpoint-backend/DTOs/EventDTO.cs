using System;
using System.Collections.Generic;

namespace DTOs
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
    }
}