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

// Connection string to local DB:
// "Server=(localdb)\\mssqllocaldb;Database=LocalMarketer;Trusted_Connection=True;"


// Azure: 
// "Server=tcp:localmarketering.database.windows.net,1433;Initial Catalog=LocalMarketeringDB;Persist Security Info=False;User ID=marek;Password=^iPoV@NA3Qs3ZY;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"