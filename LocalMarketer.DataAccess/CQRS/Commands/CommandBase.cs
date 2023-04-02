using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Commands
{
        /// <summary>
        /// Base for commands.
        /// </summary>
        /// <typeparam name="TParameter"> Data to modify the database. </typeparam>
        /// <typeparam name="TResoult"> Resoult data of the command. </typeparam>
        public abstract class CommandBase<TParameter, TResoult>
        {
                /// <summary>
                /// Gets or sets the parameter.
                /// </summary>
                public TParameter Parameter { get; set; }

                /// <summary>
                /// Executes command.
                /// </summary>
                /// <param name="context"> Context of data access </param>
                /// <returns>Result of executed command.</returns>
                public abstract Task<TResoult> Execute(LocalMarketerDbContext context);
        }
}
