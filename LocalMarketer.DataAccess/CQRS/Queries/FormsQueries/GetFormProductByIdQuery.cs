using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.FormsQueries
{
        public class GetFormProductByIdQuery : NotPagedQuery<FormProduct>
        {
                public int FormProductId { get; set; }

                public override async Task<FormProduct> Execute(LocalMarketerDbContext context)
                {
                        return await context.FormProducts
                        .Where(x => x.FormProductId == this.FormProductId)
                        .Include(x => x.Products)
                        .Include(x => x.Profile)
                        .FirstOrDefaultAsync();
                }
        }
}