using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}