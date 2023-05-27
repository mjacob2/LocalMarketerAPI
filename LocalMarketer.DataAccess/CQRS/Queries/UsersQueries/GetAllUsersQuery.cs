using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.UsersQueries
{
        public class GetAllUsersQuery : QueryBase<List<User>>
        {
                public bool? ShowOnlySellers { get; set; }

                public override Task<List<User>> Execute(LocalMarketerDbContext context)
                {
                        if (ShowOnlySellers == true)
                        {
                                return context.Users
                                    .Where(x => x.Role == "Seller")
                                    .Include(x => x.Clients)
                                    .ThenInclude(x => x.Profiles)
                                    .ThenInclude(x => x.Deals)
                                    .ThenInclude(x => x.ToDos)
                                    .ToListAsync();
                        }
                        else
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
}