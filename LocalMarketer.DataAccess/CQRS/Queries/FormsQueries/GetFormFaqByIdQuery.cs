using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.FormsQueries
{
        public class GetFormFaqByIdQuery : QueryBase<FormFaq>
        {
                public int FormFaqId { get; set; }

                public override async Task<FormFaq> Execute(LocalMarketerDbContext context)
                {
                        return await context.FormFaqs
                        .Where(x => x.FormFaqId == this.FormFaqId)
                        .Include(x => x.Profile)
                        .FirstOrDefaultAsync();
                }
        }
}
