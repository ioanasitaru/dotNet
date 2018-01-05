using System;

namespace Data.Domain.Entities
{
    public class EventTag
    {
        public Guid EventId { get; private set; }
        public Event Event { get; set; }

        public string TagLabel { get; private set; }
        public Tag Tag { get; set; }

        private EventTag() { }

        public EventTag(Guid _eventId, Event _event, string _label, Tag _tag)
        {
            EventId = _eventId;
            Event = _event;
            TagLabel = _label;
            Tag = _tag;
        }


    }
}