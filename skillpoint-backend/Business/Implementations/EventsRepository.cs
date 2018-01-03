using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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
            ITagsRepository _tagsRepository = new TagsRepository(_databaseContext);

            var @event = Event.Create(creatingModel, null);

            List<EventTag> eventTags = new List<EventTag>();

            foreach (var tag in creatingModel.Tags)
            {
                eventTags.Add(new EventTag(@event.Id,@event,tag.Label,_tagsRepository.GetById(tag.Label)));
            }
      
            @event.Update(@event.Name,@event.Description,@event.DateAndTime,@event.Location,@event.Image,eventTags);
            AddEvent(@event, creatingModel.Tags);
            _databaseContext.SaveChanges();
        }

        private void AddEvent(Event _event, List<TagCreatingModel> tags)
        {
            _databaseContext.Database.OpenConnection();

            ITagsRepository _tagsRepository = new TagsRepository(_databaseContext);

            try
            {
                foreach (var tag in tags)
                {
                    if (_tagsRepository.GetById(tag.Label) != null)
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
                var event_tags = _databaseContext.Entry(@event).Collection("Tags");

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

        public Event GetById(Guid id)
        {


            var @event = _databaseContext.Events.FirstOrDefault(e => e.Id.Equals(id));
            
            var event_tags = _databaseContext.Entry(@event).Collection("Tags");

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


        public async Task CreateAsync(EventCreatingModel model)
        {
            var @event = Event.Create(model.Name, model.Description, model.DateAndTime, model.Location, model.Image,
                null);
            await _databaseContext.Events.AddAsync(@event);

            _databaseContext.SaveChanges();
        }

        public void CreateRelations(Event @event, List<Tag> tags)
        {
            List<EventTag> eventTags = tags.ConvertAll(t => new EventTag(@event.Id, @event,t.Label,t));

            foreach (var eventTag in eventTags)
            {
                var sql = String.Format("INSERT INTO dbo.EventTag VALUES('{0}', '{1}')", @event.Id, eventTag.Tag.Label);
                _databaseContext.Database.ExecuteSqlCommand(sql);

            }
            _databaseContext.SaveChanges();
        }

        public Event GetByName(string name)
        {
           return _databaseContext.Events.FirstOrDefault(e => e.Name.Equals(name));
        }
    }
}
