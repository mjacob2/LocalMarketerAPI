using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.DealsQueries
{
        public class GetAllDealsQuery : QueryBase<List<Deal>>
        {
                public override Task<List<Deal>> Execute(LocalMarketerDbContext context)
                {
                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                return context.Deals
                                        .Include(x => x.Profile)
                                        .ThenInclude(x => x.Client)
                                        .ThenInclude(x => x.Users)
                                        .Where(x => x.Profile.Client.Users.Any(x => x.UserId == LoggedUserId))
                                        .ToListAsync();
                        }

                        else
                        {
                                return context.Deals.ToListAsync();
                        }
                }
        }
}