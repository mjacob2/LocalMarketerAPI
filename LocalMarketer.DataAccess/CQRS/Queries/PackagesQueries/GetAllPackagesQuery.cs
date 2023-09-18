using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.PackagesQueries
{
    public class GetAllPackagesQuery : NotPagedQuery<List<Package>?>
    {
        public override async Task<List<Package>?> Execute(LocalMarketerDbContext context)
        {
            return await context.Packages.ToListAsync();
        }
    }
}
