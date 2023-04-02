using System.Threading.Tasks;
using LocalMarketer.DataAccess.CQRS.Queries;

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
                public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
                {
                        return query.Execute(this.context);
                }
        }
}
