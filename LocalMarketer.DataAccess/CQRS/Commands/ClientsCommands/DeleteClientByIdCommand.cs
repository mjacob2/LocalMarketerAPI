using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands
{
        public class DeleteClientByIdCommand : CommandBase<Client, Client>
        {
                public override async Task<Client> Execute(LocalMarketerDbContext context)
                {
                        context.Clients.Remove(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}