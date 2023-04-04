using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ProfilesCommands
{
        public class AddProfileCommand : CommandBase<Profile, Profile>
        {
                public override async Task<Profile> Execute(LocalMarketerDbContext context)
                {
                        await context.Profiles.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}