using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries
{
        public class GetAllClientsQuery : QueryBase<List<Client>>
        {
                public override Task<List<Client>> Execute(LocalMarketerDbContext context)
                {
                        return context.Clients.ToListAsync();
                }
        }
}
