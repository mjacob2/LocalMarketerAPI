using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Commands.UsersCommands
{
        public class AddUserCommand : CommandBase<User, User>
        {
                public override async Task<User> Execute(LocalMarketerDbContext context)
                {
                        await context.Users.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}
