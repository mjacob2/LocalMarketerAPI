using System.Threading.Tasks;
using LocalMarketer.DataAccess.CQRS.Commands;

namespace LocalMarketer.DataAccess.CQRS
{
        /// <summary>
        /// The command executor.
        /// </summary>
        public interface ICommandExecutor
        {
                /// <summary>
                /// Execute command.
                /// </summary>
                /// <typeparam name="TParameters">Parameter.</typeparam>
                /// <typeparam name="TResoult">Parameter of resoult.</typeparam>
                /// <param name="command">command.</param>
                /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
                Task<TResoult> Execute<TParameters, TResoult>(CommandBase<TParameters, TResoult> command);
        }
}
