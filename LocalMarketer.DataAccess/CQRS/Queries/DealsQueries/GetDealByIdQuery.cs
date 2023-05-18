using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.DealsQueries
{
        public class GetDealByIdQuery : QueryBase<Deal>
        {
                public int DealId { get; set; }

                public override async Task<Deal> Execute(LocalMarketerDbContext context)
                {
                        return await context.Deals
                        .Where(x => x.DealId == this.DealId)
                        .Include(x => x.Profile)
                        .ThenInclude(x => x.Client)
                        .Include(c => c.ToDos)
                        .FirstOrDefaultAsync();
                }
        }
}