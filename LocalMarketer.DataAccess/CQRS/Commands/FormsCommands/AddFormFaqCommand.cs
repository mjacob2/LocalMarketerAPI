using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.FormsCommands
{
        public class AddFormFaqCommand : CommandBase<FormFaq, FormFaq>
        {
                public override async Task<FormFaq> Execute(LocalMarketerDbContext context)
                {
                        await context.FormFaqs.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}