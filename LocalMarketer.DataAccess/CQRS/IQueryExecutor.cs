using System.Threading.Tasks;
using LocalMarketer.DataAccess.CQRS.Queries;

namespace LocalMarketer.DataAccess.CQRS
{
        /// <summary>
        /// The query executor.
        /// </summary>
        public interface IQueryExecutor
        {
                /// <summary>
                /// Executes query.
                /// </summary>
                /// <typeparam name="TResoult">Query result.</typeparam>
                /// <param name="query">Query.</param>
                /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
                Task<TResoult> Execute<TResoult>(QueryBase<TResoult> query);
        }
}
