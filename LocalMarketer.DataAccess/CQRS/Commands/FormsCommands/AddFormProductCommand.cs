using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.FormsCommands
{
        public class AddFormProductCommand : CommandBase<FormProduct, FormProduct>
        {
                public override async Task<FormProduct> Execute(LocalMarketerDbContext context)
                {
                        await context.FormProducts.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}