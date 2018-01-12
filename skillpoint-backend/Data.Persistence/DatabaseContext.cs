using Data.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public sealed class DatabaseContext : IdentityDbContext<User>, IDatabaseContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<UserTag>().HasKey(t => new {t.UserId, t.TagLabel});

            modelBuilder.Entity<UserTag>().HasOne(u => u.User).WithMany(t => t.Tags).HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserTag>().HasOne(t => t.Tag).WithMany(u => u.UsersList).HasForeignKey(t => t.TagLabel);

            modelBuilder.Entity<EventTag>().HasKey(t => new { t.EventId, t.TagLabel });

            modelBuilder.Entity<EventTag>().HasOne(u => u.Event).WithMany(t => t.Tags).HasForeignKey(u => u.EventId);

            modelBuilder.Entity<EventTag>().HasOne(t => t.Tag).WithMany(e => e.EventsList).HasForeignKey(t => t.TagLabel);

            modelBuilder.Entity<EventUser>().HasKey(u => new { u.EventId, u.UserId });

            modelBuilder.Entity<EventUser>().HasOne(u => u.Event).WithMany(e => e.Users).HasForeignKey(u => u.EventId);

            modelBuilder.Entity<EventUser>().HasOne(u => u.User).WithMany(e => e.Events).HasForeignKey(u => u.UserId);
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<UserTag> UserTag { get; set; }
        public DbSet<EventTag> EventTag { get; set; }
    }
}