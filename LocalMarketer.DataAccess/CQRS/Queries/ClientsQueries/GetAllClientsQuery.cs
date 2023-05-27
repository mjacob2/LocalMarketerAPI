using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries
{
        public class GetAllClientsQuery : QueryBase<List<Client>>
        {
                public bool ShowOnlyUnallocated { get; set; }

                public override Task<List<Client>> Execute(LocalMarketerDbContext context)
                {
                        IQueryable<Client> query = context.Clients.Include(x => x.Users);

                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                query = query.Where(x => x.Users.Any(x => x.UserId == LoggedUserId));
                        }

                        if (ShowOnlyUnallocated)
                        {
                                query = query.Where(x => !x.Users.Any(u => u.Role ==  Roles.LocalMarketer.ToString()));
                        }

                        return query.OrderByDescending(x => x.ClientId).ToListAsync();
                }

        }
}
