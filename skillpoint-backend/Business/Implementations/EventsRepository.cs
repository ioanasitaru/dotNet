using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task CreateAsync(EventCreatingModel model)
        {
            var @event = Event.Create(model.Name, model.Description, model.DateAndTime, model.Location, model.Image,
                null, null);
            await _databaseContext.Events.AddAsync(@event);

            _databaseContext.SaveChanges();
        }

        public void CreateRelations(Event @event, List<Tag> tags)
        {
            List<EventTag> eventTags = tags.ConvertAll(t => new EventTag(@event.Id, @event, t.Label, t));

            foreach (var eventTag in eventTags)
            {
                var sql = String.Format("INSERT INTO dbo.EventTag VALUES('{0}', '{1}')", @event.Id, eventTag.Tag.Label);
                _databaseContext.Database.ExecuteSqlCommand(sql);
            }
            _databaseContext.SaveChanges();
        }

        public void CreateRelations(Event @event, List<User> users)
        {
            List<EventUser> eventUsers = users.ConvertAll(u => new EventUser(@event.Id, @event, u.Id, u));

            foreach (var eventUser in eventUsers)
            {
                var sql = String.Format("INSERT INTO dbo.EventUser VALUES('{0}', '{1}')", @event.Id, eventUser.UserId);
                _databaseContext.Database.ExecuteSqlCommand(sql);
            }
            _databaseContext.SaveChanges();
        }

        public Event GetByName(string name)
        {
            return _databaseContext.Events.FirstOrDefault(e => e.Name.Equals(name));
        }

        public void Create(EventCreatingModel entity)
        {
            throw new NotImplementedException();
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
            List<EventUser> eventUsers = new List<EventUser>();

            foreach (var tag in eventCreatingModel.Tags)
            {
                eventTags.Add(new EventTag(@event.Id, @event, tag.Label, Tag.Create(tag.Label)));
            }

            foreach (var _user in eventCreatingModel.Users)
            {
                var dbUser = _databaseContext.Users.FirstOrDefault(u => u.UserName == _user.Username);
                if (dbUser != null)
                {
                    eventUsers.Add(new EventUser(@event.Id, @event, dbUser.Id, dbUser));
                }
            }

            @event.Update(eventCreatingModel.Name, eventCreatingModel.Description, eventCreatingModel.DateAndTime,
                eventCreatingModel.Location, eventCreatingModel.Image, eventTags, eventUsers);
        }

        public void Delete(Guid id)
        {
            _databaseContext.Events.Remove(GetById(id));
            _databaseContext.SaveChanges();
        }

        public Event IsInDb(EventCreatingModel model)
        {
            return _databaseContext.Events.FirstOrDefault(e => e.Name == model.Name && e.DateAndTime == model.DateAndTime && e.Location == model.Location && e.Description == model.Description && e.Image == model.Image);
        }
    }
}