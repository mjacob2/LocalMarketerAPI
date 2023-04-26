using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Queries.DealsQueries
{
        public class GetDealByIdQuery : QueryBase<Deal>
        {
                public int DealId { get; set; }

                public override async Task<Deal> Execute(LocalMarketerDbContext context)
                {
                        return await context.Deals
                        .Where(x => x.Id == this.DealId)
                        .Include(c => c.ToDos)
                        .FirstOrDefaultAsync();
                }
        }
}