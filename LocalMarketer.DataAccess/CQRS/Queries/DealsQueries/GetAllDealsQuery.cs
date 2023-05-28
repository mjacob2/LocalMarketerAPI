using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.DealsQueries
{
        public class GetAllDealsQuery : QueryBase<PaginatedList<Deal>>
        {
                public int PageIndex { get; set; }
                public int PageSize { get; set; }

                public override Task<PaginatedList<Deal>> Execute(LocalMarketerDbContext context)
                {
                        IQueryable<Deal> query = context.Deals;

                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                query = ShowOnlyMine(query);
                        }

                        query = query.OrderByDescending(x => x.DealId);

                        var paginated = PaginatedList<Deal>.CreateAsync(query, PageIndex, PageSize);

                        return paginated;
                }

                private IQueryable<Deal> ShowOnlyMine(IQueryable<Deal> query)
                {
                        return query
                            .Include(x => x.Profile)
                            .ThenInclude(x => x.Client)
                            .ThenInclude(x => x.Users)
                            .Where(x => x.Profile.Client.Users.Any(x => x.UserId == LoggedUserId));
                }
        }
}