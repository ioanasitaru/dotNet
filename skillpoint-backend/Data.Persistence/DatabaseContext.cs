using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}