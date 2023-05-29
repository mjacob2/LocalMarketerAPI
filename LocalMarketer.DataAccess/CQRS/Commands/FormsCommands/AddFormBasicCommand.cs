using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.FormsCommands
{
        public class AddFormBasicCommand : CommandBase<FormBasic, FormBasic>
        {
                public override async Task<FormBasic> Execute(LocalMarketerDbContext context)
                {
                        await context.FormBasics.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}