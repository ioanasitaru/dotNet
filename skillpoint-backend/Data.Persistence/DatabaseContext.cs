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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTag>().HasKey(t => new {t.UserId, t.TagLabel});

            modelBuilder.Entity<UserTag>().HasOne(u => u.User).WithMany(t => t.TagsList).HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserTag>().HasOne(t => t.Tag).WithMany(u => u.UsersList).HasForeignKey(t => t.TagLabel);
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTag> UserTag { get; set; }
    }
}