using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands
{
        public class DeleteToDoByIdCommand : CommandBase<ToDo, ToDo>
        {
                public override async Task<ToDo> Execute(LocalMarketerDbContext context)
                {
                        context.ToDos.Remove(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}