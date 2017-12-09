using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}