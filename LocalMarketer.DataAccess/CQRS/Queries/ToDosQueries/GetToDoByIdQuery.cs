using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries
{
        public class GetToDoByIdQuery : QueryBase<ToDo>
        {
                public int ToDoId { get; set; }

                public override async Task<ToDo> Execute(LocalMarketerDbContext context)
                {
                        return await context.ToDos
                        .Where(x => x.ToDoId == this.ToDoId)
                        .Include(x => x.Deal)
                        .ThenInclude(x => x.Profile)
                        .ThenInclude(x => x.Client)
                        .ThenInclude(x => x.Users)
                        .Include(c => c.Notes)
                        .FirstOrDefaultAsync();
                }
        }
}