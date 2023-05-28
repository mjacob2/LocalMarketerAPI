using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries
{
        public class GetAllProfilesQuery : QueryBase<PaginatedList<Profile>>
        {
                public int PageIndex { get; set; }
                public int PageSize { get; set; }
                public override Task<PaginatedList<Profile>> Execute(LocalMarketerDbContext context)
                {
                        IQueryable<Profile> query = context.Profiles.Include(x => x.Client.Users);

                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                query = query.Where(x => x.Client.Users.Any(x => x.UserId == LoggedUserId));
                        }

                        query = query.OrderByDescending(x => x.ProfileId);

                        var paginated = PaginatedList<Profile>.CreateAsync(query, PageIndex, PageSize);

                        return paginated;
                }
        }
}
