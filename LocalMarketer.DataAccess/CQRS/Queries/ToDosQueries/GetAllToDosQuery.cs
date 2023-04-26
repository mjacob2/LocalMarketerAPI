using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries
{
        public class GetAllToDosQuery : QueryBase<List<ToDo>>
        {
                public override Task<List<ToDo>> Execute(LocalMarketerDbContext context)
                {
                        if (LoggedUserRole == Roles.Seller.ToString())
                        {
                                return context.ToDos
                                        .Where(x => x.CreatorId == LoggedUserId)
                                        .ToListAsync();
                        }
                        else
                        {
                                var tt = context.ToDos
                                        .Include(x => x.Deal)
                                        .ThenInclude(x => x.Profile)
                                        .ToListAsync();
                                return tt;
                        }
                }
        }
}