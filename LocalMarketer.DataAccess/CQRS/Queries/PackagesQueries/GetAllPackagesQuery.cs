using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.PackagesQueries
{
        public class GetAllPackagesQuery : QueryBase<List<Package>>
        {
                public override Task<List<Package>> Execute(LocalMarketerDbContext context)
                {
                                return context.Packages.ToListAsync();
                }
        }
}
