using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.UsersQueries
{
        public class GetAllUsersQuery : QueryBase<PaginatedList<User>>
        {
                public bool? ShowOnlySellers { get; set; }
                public int PageIndex { get; set; }
                public int PageSize { get; set; }

                public override Task<PaginatedList<User>> Execute(LocalMarketerDbContext context)
                {
                        IQueryable<User> query = context.Users
                            .Include(x => x.Clients)
                            .ThenInclude(x => x.Profiles)
                            .ThenInclude(x => x.Deals)
                            .ThenInclude(x => x.ToDos);

                        if (ShowOnlySellers == true)
                        {
                                query = query.Where(x => x.Role == "Seller");
                        }

                        var paginated = PaginatedList<User>.CreateAsync(query, PageIndex, PageSize);

                        return paginated;
                }

        }
}