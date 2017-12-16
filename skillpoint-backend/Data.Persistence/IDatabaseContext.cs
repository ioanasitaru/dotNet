using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserTag> UserTag { get; set; }
        int SaveChanges();
        EntityEntry Entry(object entity);
        DatabaseFacade Database { get; }
    }
}