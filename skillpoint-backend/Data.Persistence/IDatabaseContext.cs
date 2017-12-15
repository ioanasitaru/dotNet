using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    }
}