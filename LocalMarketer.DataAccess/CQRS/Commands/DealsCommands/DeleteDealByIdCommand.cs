using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.DealsCommands
{
        public class DeleteDealByIdCommand : CommandBase<Deal, Deal>
        {
                public override async Task<Deal> Execute(LocalMarketerDbContext context)
                {
                        context.Deals.Remove(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}