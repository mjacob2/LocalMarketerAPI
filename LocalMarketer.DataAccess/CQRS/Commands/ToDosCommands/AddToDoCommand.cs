using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands
{
        public class AddToDoCommand : CommandBase<ToDo, ToDo>
        {
                public override async Task<ToDo> Execute(LocalMarketerDbContext context)
                {
                        await context.ToDos.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}