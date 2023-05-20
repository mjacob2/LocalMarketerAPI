using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.FormsCommands
{
        public class AddFormServiceCommand : CommandBase<FormService, FormService>
        {
                public override async Task<FormService> Execute(LocalMarketerDbContext context)
                {
                        await context.FormServices.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}