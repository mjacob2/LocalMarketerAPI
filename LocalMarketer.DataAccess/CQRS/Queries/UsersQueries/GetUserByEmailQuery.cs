using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS.Queries.UserQueries
{
        /// <summary>
        /// The get user by username query.
        /// </summary>
        public class GetUserByEmailQuery : NotPagedQuery<User>
        {
                /// <summary>
                /// Gets or sets the username.
                /// </summary>
                public string Email { get; set; } = string.Empty;

                /// <summary>
                /// Executes the.
                /// </summary>
                /// <param name="context">The context.</param>
                /// <returns>A Task.</returns>
                public override Task<User> Execute(LocalMarketerDbContext context)
                {
                        return context.Users.FirstOrDefaultAsync(x => x.Email == this.Email);
                }
        }
}
