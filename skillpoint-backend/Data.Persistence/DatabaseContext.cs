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
        public DbSet<Data.Domain.Entities.Tag> Tags { get; set; }
        public DbSet<Data.Domain.Entities.Event> Events { get; set; }
        public DbSet<Data.Domain.Entities.User> Users { get; set; }
    }
}