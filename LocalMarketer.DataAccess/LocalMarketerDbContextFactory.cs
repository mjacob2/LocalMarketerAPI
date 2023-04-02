using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace LocalMarketer.DataAccess
{
        public class LocalMarketerDbContextFactory : IDesignTimeDbContextFactory<LocalMarketerDbContext>
        {
                public LocalMarketerDbContext CreateDbContext(string[] args)
                {
                        var optionsBuilder = new DbContextOptionsBuilder<LocalMarketerDbContext>();
                        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LocalMarketer;Trusted_Connection=True;");
                        return new LocalMarketerDbContext(optionsBuilder.Options);

                }
        }
}

// Connection string to local DB: "Server=(localdb)\\mssqllocaldb;Database=LocalMarketer;Trusted_Connection=True;"