using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands
{
        public class AddClientCommand : CommandBase<Client, Client>
        {
                public override async Task<Client> Execute(LocalMarketerDbContext context)
                {
                        await context.Clients.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}