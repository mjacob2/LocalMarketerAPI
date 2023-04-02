using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess
{
        public class LocalMarketerDbContext : DbContext
        {
                public LocalMarketerDbContext(DbContextOptions<LocalMarketerDbContext> options)
                        : base(options) { }

                public DbSet<User> Users => this.Set<User>();

                public DbSet<Client> Clients => this.Set<Client>();

                public DbSet<Profile> Profiles => this.Set<Profile>();

                public DbSet<Activity> Activities => this.Set<Activity>();

                public DbSet<Deal> Deals => this.Set<Deal>();

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.Entity<User>()
                                .HasIndex(u => u.Email)
                                .IsUnique();

                        modelBuilder.Entity<Client>()
                                .HasIndex(u => u.Email)
                                .IsUnique();

                        modelBuilder.Entity<Profile>()
                                .HasIndex(u => u.Name)
                                .IsUnique();
                }

        }
}
