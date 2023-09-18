using System.Threading.Tasks;
using LocalMarketer.DataAccess.CQRS.Queries;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.DataAccess.CQRS
{
    /// <summary>
    /// The query executor.
    /// </summary>
    public class QueryExecutor : IQueryExecutor
    {
        private readonly LocalMarketerDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryExecutor"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public QueryExecutor(LocalMarketerDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public Task<TResult?> Execute<TResult>(NotPagedQuery<TResult?> query)
        {
            return query.Execute(this.context);
        }

        public Task<TResult?> Execute<TResult>(PagedQuery<TResult?> query)
        {
            return query.Execute(this.context);
        }
    }
}
