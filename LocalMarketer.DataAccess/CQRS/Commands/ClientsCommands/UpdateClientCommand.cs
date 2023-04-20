using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands
{
        public class UpdateClientCommand : CommandBase<Client, Client>
        {
                /// <summary>
                /// Executes the.
                /// </summary>
                /// <param name="context">The context.</param>
                /// <returns>A Task.</returns>
                public override async Task<Client> Execute(LocalMarketerDbContext context)
                {
                        context.Clients.Update(this.Parameter);
                        context.Entry(this.Parameter)
                                .Property(x => x.CreationDate).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreatorId).IsModified = false;
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}
