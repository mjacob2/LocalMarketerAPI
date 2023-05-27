using Azure.Core;
using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands
{
        public class UpdateClientCommand : CommandBase<Client, Client>
        {
                public override async Task<Client> Execute(LocalMarketerDbContext context)
                {
                        var existingClient = await context.Clients.Where(x => x.ClientId == this.Parameter.ClientId)
                                .Include(x => x.Users)
                                .FirstOrDefaultAsync();

                        if(existingClient != null)
                        {
                                existingClient.ClientUsers.Clear();
                                await context.SaveChangesAsync();
                        }
                        
                        context.ChangeTracker.Clear();

                        context.Clients.Update(this.Parameter);
                        context.Entry(this.Parameter)
                                .Property(x => x.CreationDate).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreatorId).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreatorFullName).IsModified = false;
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}
