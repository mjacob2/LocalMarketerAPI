using Azure.Core;
using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands
{
        public class UpdateClientCommand : CommandBase<Client, Client>
        {
                public int SellerId { get; set; }
                public int UserId { get; set; }

                /// <summary>
                /// Executes the.
                /// </summary>
                /// <param name="context">The context.</param>
                /// <returns>A Task.</returns>
                public override async Task<Client> Execute(LocalMarketerDbContext context)
                {
                        var existingClient = await context.Clients.Where(x => x.ClientId == this.Parameter.ClientId)
                                .Include(x => x.Users)
                                .FirstOrDefaultAsync();

                        //existingClient.Users.Clear();

                        existingClient.ClientUsers.Clear();

                        await context.SaveChangesAsync();

                        foreach (var item in this.Parameter.ClientUsers)
                        {
                                existingClient.ClientUsers.Add(new ClientUser
                                {
                                        UserId = item.UserId,
                                });
                        }


                       context.ChangeTracker.Clear();

                        //var sellerToUpdate = existingClient.Users
                        //        .FirstOrDefault(cu => cu.Role == User.Roles.Seller.ToString());



                        //var userToUpdate = existingClient.Users
                        //        .FirstOrDefault(cu => cu.Role == User.Roles.LocalMarketer.ToString());

                        //existingClient.ClientUsers.Where(x => x.UserId == userToUpdate.UserId).Select(x => x.UserId = userToUpdateId);

                        //var tt = existingClient.ClientUsers.Select(x =>
                        //{
                        //        x.UserId = x.UserId + 1;
                        //        return x;
                        //}).ToList();

                        //existingClient.ClientUsers = tt;

                        //this.Parameter = existingClient;


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
