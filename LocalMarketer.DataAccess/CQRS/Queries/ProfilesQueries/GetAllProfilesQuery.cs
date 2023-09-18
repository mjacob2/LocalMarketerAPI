using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries
{
    public class GetAllProfilesQuery : PagedQuery<List<Profile>>
    {
        public override async Task<List<Profile>?> Execute(LocalMarketerDbContext context)
        {
            IQueryable<Profile> query = context.Profiles.Include(x => x.Client.Users);

            if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
            {
                query = query.Where(x => x.Client.Users.Any(x => x.Id == LoggedUserId));
            }

            return await GetPaginatedResult(query);
        }
    }
}
