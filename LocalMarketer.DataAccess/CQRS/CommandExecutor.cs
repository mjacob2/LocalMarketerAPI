using System.Threading.Tasks;
using LocalMarketer.DataAccess.CQRS.Commands;

namespace LocalMarketer.DataAccess.CQRS
{
        /// <summary>
        /// The command executor.
        /// </summary>
        public class CommandExecutor : ICommandExecutor
        {
                private readonly LocalMarketerDbContext context;

                /// <summary>
                /// Initializes a new instance of the <see cref="CommandExecutor"/> class.
                /// </summary>
                /// <param name="context">The context.</param>
                public CommandExecutor(LocalMarketerDbContext context)
                {
                        this.context = context;
                }

                /// <inheritdoc/>
                public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
                {
                        return command.Execute(this.context);
                }
        }
}