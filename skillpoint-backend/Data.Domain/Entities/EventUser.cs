using System;

namespace Data.Domain.Entities
{
    public class EventUser
    {
        public Guid EventId { get; private set; }
        public Event Event { get; set; }

        public string UserId { get; private set; }
        public User User { get; set; }

        private EventUser() { }

        public EventUser(Guid _eventId, Event _event, string _id, User _user)
        {
            EventId = _eventId;
            Event = _event;
            UserId = _id;
            User = _user;
        }


    }
}
