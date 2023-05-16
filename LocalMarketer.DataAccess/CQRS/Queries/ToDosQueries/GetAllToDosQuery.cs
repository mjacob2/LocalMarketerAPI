using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries
{
        public class GetAllToDosQuery : QueryBase<List<ToDo>>
        {
                public bool? ShowOnlyUnfinished { get; set; }

                public override Task<List<ToDo>> Execute(LocalMarketerDbContext context)
                {

                        if (this.ShowOnlyUnfinished == true)
                        {
                                if (LoggedUserRole == Roles.Seller.ToString())
                                {
                                        return context.ToDos
                                                .Where(x => !x.IsFinished)
                                                .Include(x => x.Deal)
                                                .ThenInclude(x => x.Profile)
                                                .Where(x => x.Deal.Profile.Client.UserId == LoggedUserId)
                                                .ToListAsync();
                                }

                                if (LoggedUserRole == Roles.LocalMarketer.ToString())
                                {
                                        return context.ToDos
                                                .Where(x => !x.IsFinished)
                                                .Include(x => x.Deal)
                                                .ThenInclude(x => x.Profile)
                                                .Where(x => x.Deal.Profile.Client.UserId == LoggedUserId)
                                                .ToListAsync();
                                }
                                else
                                {
                                        var tt = context.ToDos
                                                .Where(x => !x.IsFinished)
                                                .Include(x => x.Deal)
                                                .ThenInclude(x => x.Profile)
                                                .ToListAsync();
                                        return tt;
                                }
                        }

                        if (LoggedUserRole == Roles.Seller.ToString())
                        {
                                return context.ToDos
                                        .Where(x => x.CreatorId == LoggedUserId)
                                        .Include(x => x.Deal)
                                        .ThenInclude(x => x.Profile)
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