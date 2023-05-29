using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess
{
        public class LocalMarketerDbContext : DbContext
        {
                public LocalMarketerDbContext(DbContextOptions<LocalMarketerDbContext> options)
                        : base(options) { }

                public DbSet<User> Users { get; set; }

                public DbSet<Client> Clients { get; set; }

                public DbSet<Profile> Profiles { get; set; }

                public DbSet<ToDo> ToDos { get; set; }

                public DbSet<Deal> Deals { get; set; }

                public DbSet<Note> Notes { get; set; }
                public DbSet<Package> Packages { get; set; }

                public DbSet<Attachment> Attachments { get; set; }

                public DbSet<FormFaq> FormFaqs { get; set; }

                public DbSet<FormService> FormServices { get; set; }
                public DbSet<Service> Services { get; set; }

                public DbSet<FormProduct> FormProducts { get; set; }
                public DbSet<Product> Products { get; set; }

                public DbSet<FormBasic> FormBasics { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.Entity<User>()
                                .HasMany(e => e.Clients)
                                .WithMany(e => e.Users)
                                .UsingEntity<ClientUser>();


                        modelBuilder.Entity<User>()
                                .HasIndex(u => u.Email)
                                .IsUnique();

                        modelBuilder.Entity<Client>()
                                .HasIndex(u => u.Email)
                                .IsUnique();

                        modelBuilder.Entity<Profile>()
                                .HasIndex(u => u.GoogleProfileId)
                                .IsUnique();
                }

        }
}
