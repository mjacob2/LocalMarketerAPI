using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.FormsQueries
{
        public class GetFormBasicByIdQuery : QueryBase<FormBasic>
        {
                public int FormBasicId { get; set; }

                public override async Task<FormBasic> Execute(LocalMarketerDbContext context)
                {
                        return await context.FormBasics
                        .Where(x => x.FormBasicId == this.FormBasicId)
                        .Include(x => x.Profile)
                        .FirstOrDefaultAsync();
                }
        }
}
