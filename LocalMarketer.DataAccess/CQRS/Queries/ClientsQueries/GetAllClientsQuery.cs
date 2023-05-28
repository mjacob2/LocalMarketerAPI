using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries
{
        public class GetAllClientsQuery : QueryBase<PaginatedList<Client>>
        {
                public bool ShowOnlyUnallocated { get; set; }
                public int PageIndex { get; set; }
                public int PageSize { get; set; }

                public override Task<PaginatedList<Client>> Execute(LocalMarketerDbContext context)
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

                        query = query.OrderByDescending(x => x.ClientId);

                        var paginated = PaginatedList<Client>.CreateAsync(query, PageIndex, PageSize);

                        return paginated;
                }

        }
}
