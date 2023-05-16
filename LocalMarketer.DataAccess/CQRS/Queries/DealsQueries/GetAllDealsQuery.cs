using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.DealsQueries
{
        public class GetAllDealsQuery : QueryBase<List<Deal>>
        {
                public override Task<List<Deal>> Execute(LocalMarketerDbContext context)
                {
                        if (LoggedUserRole == Roles.Seller.ToString())
                        {
                                return context.Deals
                                        .Where(x => x.CreatorId == LoggedUserId)
                                        .ToListAsync();
                        }
                        if (LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                return context.Deals
                                        .Where(x => x.Profile.Client.UserId == LoggedUserId)
                                        .ToListAsync();
                        }

                        else
                        {
                                return context.Deals.ToListAsync();
                        }
                }
        }
}