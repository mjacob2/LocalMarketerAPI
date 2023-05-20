using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries
{
        public class GetAllToDosQuery : QueryBase<List<ToDo>>
        {
                private Task<List<ToDo>>? toDos;

                public bool? ShowOnlyUnfinished { get; set; }

                public override Task<List<ToDo>> Execute(LocalMarketerDbContext context)
                {

                        if (LoggedUserRole == Roles.Seller.ToString() || LoggedUserRole == Roles.LocalMarketer.ToString())
                        {
                                this.toDos = context.ToDos
                                        .Include(x => x.Deal)
                                        .ThenInclude(x => x.Profile)
                                        .ThenInclude(x => x.Client)
                                        .ThenInclude(x => x.Users)
                                        .Where(x => x.Deal.Profile.Client.Users.Any(x => x.UserId == LoggedUserId))
                                        .Where(x => x.ForRole == LoggedUserRole)
                                        .ToListAsync();
                        }

                        else
                        {
                                this.toDos = context.ToDos
                                        .Include(x => x.Deal)
                                        .ThenInclude(x => x.Profile)
                                        .ThenInclude(x => x.Client)
                                        .ThenInclude(x => x.Users)
                                        .ToListAsync();
                        }

                        return toDos;
                }
        }
}