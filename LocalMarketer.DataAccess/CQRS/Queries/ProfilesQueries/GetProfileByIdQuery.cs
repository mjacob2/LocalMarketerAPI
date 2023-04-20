using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries
{
        public class GetProfileByIdQuery : QueryBase<Profile>
        {
                public int ProfileId { get; set; }

                public override async Task<Profile> Execute(LocalMarketerDbContext context)
                {
                        return await context.Profiles
                        .Where(x => x.Id == this.ProfileId)
                        .Include(c => c.Activities)
                        .Include(c => c.Deals)
                        .FirstOrDefaultAsync();
                }
        }
}