using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
