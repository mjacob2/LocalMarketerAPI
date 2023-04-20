using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.ProfilesCommands
{
        public class UpdateProfileCommand : CommandBase<Profile, Profile>
        {
                /// <summary>
                /// Executes the.
                /// </summary>
                /// <param name="context">The context.</param>
                /// <returns>A Task.</returns>
                public override async Task<Profile> Execute(LocalMarketerDbContext context)
                {
                        context.Profiles.Update(this.Parameter);
                        context.Entry(this.Parameter)
                                .Property(x => x.CreationDate).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreatorId).IsModified = false;
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}