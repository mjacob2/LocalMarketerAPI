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
                        .Where(x => x.Id == this.ToDoId)
                        .Include(x => x.Deal)
                        .ThenInclude(x => x.Profile)
                        .Include(c => c.Notes)
                        .FirstOrDefaultAsync();
                }
        }
}