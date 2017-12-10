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
<<<<<<< HEAD

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
=======
        public DbSet<Tag> Tags { get; set; }
>>>>>>> b63253666cfafb1243ffd5fa725aff98d50c5661
    }
}