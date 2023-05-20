using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Queries.FormsQueries
{
        public class GetFormServiceByIdQuery : QueryBase<FormService>
        {
                public int FormServiceId { get; set; }

                public override async Task<FormService> Execute(LocalMarketerDbContext context)
                {
                        return await context.FormServices
                        .Where(x => x.FormServiceId == this.FormServiceId)
                        .Include(x => x.Services)
                        .Include(x => x.Profile)
                        .FirstOrDefaultAsync();
                }
        }
}