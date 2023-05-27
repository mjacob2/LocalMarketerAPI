using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.DealsQueries
{
        public class GetAllDealsQuery : QueryBase<List<Deal>>
        {
                public override Task<List<Deal>> Execute(LocalMarketerDbContext context)
                {
                        IQueryable<Deal> query = context.Deals;

                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                query = ShowOnlyMine(query);
                        }

                        return query.OrderByDescending(x => x.DealId).ToListAsync();
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