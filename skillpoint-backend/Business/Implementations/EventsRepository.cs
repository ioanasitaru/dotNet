using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Business.Repositories.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using DTOs;

namespace Business.Repositories.Implementations
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public EventsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(EventCreatingModel creatingModel)
        {
            ITagsRepository tagsRepository = new TagsRepository(_databaseContext);

            var @event = Event.Create(creatingModel, null);

            List<EventTag> eventTags = new List<EventTag>();

            foreach (var tag in creatingModel.Tags)
            {
                eventTags.Add(new EventTag(@event.Id,@event,tag.Label,tagsRepository.GetById(tag.Label)));
            }
      
            @event.Update(@event.Name,@event.Description,@event.DateAndTime,@event.Location,@event.Image,eventTags);
            AddEvent(@event, creatingModel.Tags);
            _databaseContext.SaveChanges();
            GetById(@event.Id);
        }

        private void AddEvent(Event _event, List<TagCreatingModel> tags)
        {
            _databaseContext.Database.OpenConnection();

            ITagsRepository tagsRepository = new TagsRepository(_databaseContext);

            try
            {
                foreach (var tag in tags)
                {
                    if (tagsRepository.GetById(tag.Label) != null)
                    {
                        var sql = String.Format(
                            "INSERT INTO dbo.Events VALUES('{0}','{1}','{2}',CONVERT(varbinary,'{3}'),'{4}','{5}')",
                            _event.Id, _event.DateAndTime, _event.Description, _event.Image, _event.Location,
                            _event.Name);
                        _databaseContext.Database.ExecuteSqlCommand(sql);

                        sql = String.Format("INSERT INTO dbo.EventTag VALUES('{0}', '{1}')", _event.Id, tag.Label);
                        _databaseContext.Database.ExecuteSqlCommand(sql);
                        _databaseContext.SaveChanges();
                    }
                    else
                    {
                        var sql = String.Format(
                            "INSERT INTO dbo.Events VALUES('{0}','{1}','{2}',CONVERT(varbinary,'{3}'),'{4}','{5}')",
                            _event.Id, _event.DateAndTime, _event.Description, _event.Image, _event.Location,
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
        
        public IReadOnlyList<Event> GetAll()
        {
            List<Event> events = new List<Event>();

            foreach (var @event in _databaseContext.Events.ToList())
            {
                var eventTags = _databaseContext.Entry(@event).Collection("Tags");

                if (!eventTags.IsLoaded)
                {
                    eventTags.Load();

                }

                foreach (var et in eventTags.CurrentValue)
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

        public Event GetById(Guid id)
        {
            var @event = _databaseContext.Events.FirstOrDefault(e => e.Id.Equals(id));
            
            var eventTags = _databaseContext.Entry(@event).Collection("Tags");

            if (!eventTags.IsLoaded)
            {
                eventTags.Load();

            }

            foreach (var et in eventTags.CurrentValue)
            {
                var tags = _databaseContext.Entry(et).Reference("Tag");

                if (!tags.IsLoaded)
                {
                    tags.Load();

                }
            }

            return @event;

        }

        public void Update(EventCreatingModel eventCreatingModel, Guid id)
        {
            var @event = GetById(id);

            List<EventTag> eventTags = new List<EventTag>();

            foreach (var tag in eventCreatingModel.Tags)
            {
                eventTags.Add(new EventTag(@event.Id, @event, tag.Label, Tag.Create(tag.Label)));
            }

            @event.Update(eventCreatingModel.Name, eventCreatingModel.Description, eventCreatingModel.DateAndTime,
                eventCreatingModel.Location, eventCreatingModel.Image, eventTags);

        }

        public void Delete(Guid id)
        {
            _databaseContext.Events.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }


    }
}
