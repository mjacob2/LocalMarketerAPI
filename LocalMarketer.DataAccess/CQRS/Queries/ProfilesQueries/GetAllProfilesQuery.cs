using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries
{
        public class GetAllProfilesQuery : QueryBase<List<Profile>>
        {
                public override Task<List<Profile>> Execute(LocalMarketerDbContext context)
                {
                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                return context.Profiles
                                        .Where(x => x.Client.Users.Any(x => x.UserId == LoggedUserId))
                                        .ToListAsync();
                        }
                        else
                        {
                                return context.Profiles.ToListAsync();
                        }
                }
        }
}
