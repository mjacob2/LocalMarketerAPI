using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries
{
        public class GetAllToDosQuery : QueryBase<PaginatedList<ToDo>>
        {
                public bool ShowOnlyUnfinished { get; set; }
                public bool ShowOnlyFinished { get; set; }
                public int PageIndex { get; set; }
                public int PageSize { get; set; }
                public override Task<PaginatedList<ToDo>> Execute(LocalMarketerDbContext context)
                {
                        IQueryable<ToDo> query = context.ToDos
                            .Include(x => x.Deal.Profile.Client.Users);

                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                query = query.Where(x => x.Deal.Profile.Client.Users.Any(x => x.UserId == LoggedUserId) && x.ForRole == LoggedUserRole);
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

                        var paginated = PaginatedList<ToDo>.CreateAsync(query, PageIndex, PageSize);

                        return paginated;
                }
        }
}