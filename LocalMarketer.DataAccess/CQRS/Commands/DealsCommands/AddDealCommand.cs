using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.DealsCommands
{
        public class AddDealCommand : CommandBase<Deal, Deal>
        {
                public override async Task<Deal> Execute(LocalMarketerDbContext context)
                {
                        await context.Deals.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}