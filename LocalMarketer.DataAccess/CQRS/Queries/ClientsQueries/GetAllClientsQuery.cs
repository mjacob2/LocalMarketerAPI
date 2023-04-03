using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries
{
        public class GetAllClientsQuery : QueryBase<List<Client>>
        {
                public override Task<List<Client>> Execute(LocalMarketerDbContext context)
                {
                        if (LoggedUserRole == Roles.Seller.ToString())
                        {
                                return context.Clients
                                        .Where(x => x.CreatorId == LoggedUserId)
                                        .ToListAsync();
                        }
                        else
                        {
                                return context.Clients.ToListAsync();
                        }
                }
        }
}
