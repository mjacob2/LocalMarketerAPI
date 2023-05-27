using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Queries
{
        /// <summary>
        /// Provides base for queries.
        /// </summary>
        /// <typeparam name="TResult">Type of query result.</typeparam>
        public abstract class QueryBase<TResult>
        {
                /// <summary>
                /// Gets or sets the logged user id.
                /// </summary>
                public int LoggedUserId { get; set; }

                public string LoggedUserRole { get; set; }

                //public int PageIndex { get; set; }
                //public int PageSize { get; set; } = 30;

                /// <summary>
                /// Executes query.
                /// </summary>
                /// <param name="context">Context of db.</param>
                /// <returns>Query result.</returns>
                public abstract Task<TResult> Execute(LocalMarketerDbContext context);
        }
}
