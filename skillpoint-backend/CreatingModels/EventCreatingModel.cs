using System;
using System.Collections.Generic;

namespace CreatingModels
{
    public class EventCreatingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public List<TagCreatingModel> Tags { get; set; }
    }
}
