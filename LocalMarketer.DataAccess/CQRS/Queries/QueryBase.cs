using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Queries
{
        /// <summary>
        /// Provides base for queries.
        /// </summary>
        /// <typeparam name="TResoult">Type of query reoult.</typeparam>
        public abstract class QueryBase<TResoult>
        {
                /// <summary>
                /// Gets or sets the logged user id.
                /// </summary>
                public int LoggedUserId { get; set; }

                public string LoggedUserRole { get; set; }

                /// <summary>
                /// Executes query.
                /// </summary>
                /// <param name="context">Context of db.</param>
                /// <returns>Query result.</returns>
                public abstract Task<TResoult> Execute(LocalMarketerDbContext context);
        }
}
