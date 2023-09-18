using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.UsersQueries
{
    public class GetAllUsersQuery : PagedQuery<List<User>>
    {
        public bool? ShowOnlySellers { get; set; }

        public override async Task<List<User>?> Execute(LocalMarketerDbContext context)
        {
            IQueryable<User> query = context.Users
                            .Include(x => x.Clients)
                            .ThenInclude(x => x.Profiles)
                            .ThenInclude(x => x.Deals)
                            .ThenInclude(x => x.ToDos);

            if (ShowOnlySellers == true)
            {
                query = query.Where(x => x.Role == "Seller");
            }

            return await GetPaginatedResult(query);
        }
    }
}