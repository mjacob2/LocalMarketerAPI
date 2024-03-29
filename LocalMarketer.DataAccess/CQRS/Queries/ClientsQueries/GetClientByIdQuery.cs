﻿using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries
{
        public class GetClientByIdQuery : NotPagedQuery<Client>
        {
                public int ClientId { get; set; }

                public override async Task<Client?> Execute(LocalMarketerDbContext context)
                {
                                return await context.Clients
                                .Where(x => x.Id == this.ClientId)
                                .Include(x => x.ClientUsers)
                                .ThenInclude(x => x.User)
                                .Include(c => c.Profiles)
                                .FirstOrDefaultAsync();
                }
        }
}
