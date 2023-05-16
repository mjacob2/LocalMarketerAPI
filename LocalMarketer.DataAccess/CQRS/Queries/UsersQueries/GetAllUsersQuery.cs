using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.UsersQueries
{
        public class GetAllUsersQuery : QueryBase<List<User>>
        {
                public override Task<List<User>> Execute(LocalMarketerDbContext context)
                {
                        return context.Users
                                .Include(x => x.Clients)
                                .ThenInclude(x => x.Profiles)
                                .ThenInclude(x => x.Deals)
                                .ThenInclude(x => x.ToDos)
                                .ToListAsync();
                }
        }
}