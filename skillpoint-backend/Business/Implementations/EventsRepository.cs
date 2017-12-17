using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories.Implementations
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public EventsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Event CreateEvent(EventCreatingModel creatingModel, List<Tag> tags)
        {
            var @event = Event.Create(creatingModel, null);

            List<EventTag> eventTags = new List<EventTag>();

            foreach (var tag in tags)
            {
                eventTags.Add(new EventTag(@event.Id,@event,tag.Label,tag));
            }
      
            @event.Update(@event.Name,@event.Description,@event.DateAndTime,@event.Location,@event.Image,eventTags);
            AddEvent(@event, tags);
            _databaseContext.SaveChanges();

            return _databaseContext.Events.FirstOrDefault(e => e.Id.Equals(@event.Id));
        }

        private void AddEvent(Event _event, List<Tag> tags)
        {
            _databaseContext.Database.OpenConnection();

            ITagsRepository _tagsRepository = new TagsRepository(_databaseContext);

            try
            {
                foreach (var tag in tags)
                {
                    if (_tagsRepository.GetTagByLabel(tag.Label) != null)
                    {
                        var sql = String.Format("INSERT INTO dbo.Events VALUES('{0}','{1}','{2}',CONVERT(varbinary,'{3}'),'{4}','{5}')",
                            _event.Id, _event.DateAndTime, _event.Description, _event.Image, _event.Location,
                            _event.Name);
                        _databaseContext.Database.ExecuteSqlCommand(sql);

                        sql = String.Format("INSERT INTO dbo.EventTag VALUES('{0}', '{1}')", _event.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                    else
                    {
                        var sql = String.Format("INSERT INTO dbo.Events VALUES('{0}','{1}','{2}',CONVERT(varbinary,'{3}'),'{4}','{5}')",
                            _event.Id, _event.DateAndTime, _event.Description,_event.Image, _event.Location,
                            _event.Name);
                        _databaseContext.Database.ExecuteSqlCommand(sql);

                        sql = String.Format("INSERT INTO dbo.Tags VALUES('{0}','{1}')", tag.Label, tag.Verified);
                        _databaseContext.Database.ExecuteSqlCommand(sql);

                        sql = String.Format("INSERT INTO dbo.EventTag VALUES('{0}', '{1}')", _event.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                }
            }
            finally
            {
                _databaseContext.Database.CloseConnection();
            }
        }

        public IReadOnlyList<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            foreach (var @event in _databaseContext.Events.ToList())
            {
                var event_tags = _databaseContext.Entry(@event).Collection("TagList");

                if (!event_tags.IsLoaded)
                {
                    event_tags.Load();

                }

                foreach (var et in event_tags.CurrentValue)
                {
                    var tags = _databaseContext.Entry(et).Reference("Tag");

                    if (!tags.IsLoaded)
                    {
                        tags.Load();

                    }
                }

                events.Add(@event);

            }

            return events;
        }

        public Event GetEventById(Guid id)
        {



            var @event = _databaseContext.Events.FirstOrDefault(e => e.Id.Equals(id));
            
            var event_tags = _databaseContext.Entry(@event).Collection("TagList");

            if (!event_tags.IsLoaded)
            {
                event_tags.Load();

            }

            foreach (var et in event_tags.CurrentValue)
            {
                var tags = _databaseContext.Entry(et).Reference("Tag");

                if (!tags.IsLoaded)
                {
                    tags.Load();

                }
            }

            return @event;

        }

        public void UpdateEvent(EventCreatingModel eventCreatingModel, Guid id)
        {
            var @event = GetEventById(id);

            List<EventTag> eventTags = new List<EventTag>();

            foreach (var tag in eventCreatingModel.Tags)
            {
                eventTags.Add(new EventTag(@event.Id,@event,tag.Label,Tag.Create(tag)));
            }

            @event.Update(eventCreatingModel.Name,eventCreatingModel.Description,eventCreatingModel.DateAndTime,eventCreatingModel.Location,eventCreatingModel.Image,eventTags);

            _databaseContext.Events.Update(@event);
            _databaseContext.SaveChanges();
        }

        public void DeleteEvent(Guid id)
        {
            _databaseContext.Events.Remove(GetEventById(id));
            _databaseContext.SaveChanges();
        }


    }
}
