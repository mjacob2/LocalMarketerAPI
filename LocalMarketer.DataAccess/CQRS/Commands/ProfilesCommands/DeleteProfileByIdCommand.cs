using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ProfilesCommands
{
        public class DeleteProfileByIdCommand : CommandBase<Profile, Profile>
        {
                public override async Task<Profile> Execute(LocalMarketerDbContext context)
                {
                        context.Profiles.Remove(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}