﻿using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries
{
        public class GetClientByIdQuery : QueryBase<Client>
        {
                public int ClientId { get; set; }

                public override async Task<Client> Execute(LocalMarketerDbContext context)
                {
                                return await context.Clients
                                .Where(x => x.Id == this.ClientId)
                                .Include(c => c.Profiles)
                                .Include(c => c.Deals)
                                .FirstOrDefaultAsync();
                }
        }
}
