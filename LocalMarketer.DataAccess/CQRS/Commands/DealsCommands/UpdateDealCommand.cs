﻿using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.DealsCommands
{
        public class UpdateDealCommand : CommandBase<Deal, Deal>
        {
                public override async Task<Deal> Execute(LocalMarketerDbContext context)
                {
                        context.Deals.Update(this.Parameter);

                        context.Entry(this.Parameter)
                                .Property(x => x.ProfileId).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreationDate).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreatorId).IsModified = false;

                        await context.SaveChangesAsync();

                        return this.Parameter;
                }
        }
}
