using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Queries
{
    /// <summary>
    /// Provides base for queries.
    /// </summary>
    /// <typeparam name="TResult">Type of query result.</typeparam>
    public abstract class NotPagedQuery<TResult> : QueryBase
    {
        /// <summary>
        /// Executes query.
        /// </summary>
        /// <param name="context">Context of db.</param>
        /// <returns>Query result.</returns>
        public abstract Task<TResult?> Execute(LocalMarketerDbContext context);
    }
}
