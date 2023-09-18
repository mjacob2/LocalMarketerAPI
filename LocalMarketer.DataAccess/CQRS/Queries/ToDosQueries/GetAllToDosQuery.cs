using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries
{
    public class GetAllToDosQuery : PagedQuery<List<ToDo>>
    {
        public bool ShowOnlyUnfinished { get; set; }
        public bool ShowOnlyFinished { get; set; }

        public override async Task<List<ToDo>?> Execute(LocalMarketerDbContext context)
        {
            IQueryable<ToDo> query = context.ToDos
                .Include(x => x.Deal.Profile.Client.Users);

            if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
            {
                query = query.Where(x => x.Deal.Profile.Client.Users.Any(x => x.Id == LoggedUserId) && x.ForRole == LoggedUserRole);
            }

            if (ShowOnlyUnfinished)
            {
                query = query.Where(x => !x.IsFinished);
            }

            if (ShowOnlyFinished)
            {
                query = query.Where(x => x.IsFinished);
            }

            query = query.OrderBy(x => x.DueDate).ThenBy(x => x.Deal.ProfileId);

            Func<IQueryable<ToDo>, IOrderedQueryable<ToDo>> order = query =>
    query.OrderBy(x => x.DueDate).ThenBy(x => x.Deal.ProfileId);

            return await GetPaginatedResult(query, order);
        }
    }
}