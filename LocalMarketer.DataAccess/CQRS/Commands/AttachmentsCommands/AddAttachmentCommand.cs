using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.AttachmentsCommands
{
        public class AddAttachmentCommand : CommandBase<Attachment, Attachment>
        {
                public override async Task<Attachment> Execute(LocalMarketerDbContext context)
                {
                        await context.Attachments.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}