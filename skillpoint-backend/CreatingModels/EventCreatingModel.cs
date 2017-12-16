using System;
using Data.Domain.Entities;

namespace CreatingModels
{
    public class EventCreatingModel : CreatingModel<Event>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }
    }
}
