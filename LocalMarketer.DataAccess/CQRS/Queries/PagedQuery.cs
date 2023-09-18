using LocalMarketer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketer.DataAccess.CQRS.Queries
{
    public abstract class PagedQuery<TResult> : QueryBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        /// <summary>
        /// Executes query.
        /// </summary>
        /// <param name="context">Context of db.</param>
        /// <returns>Query result.</returns>
        public abstract Task<TResult?> Execute(LocalMarketerDbContext context);

        protected async Task<List<T>?> GetPaginatedResult<T>(IQueryable<T> query, Func<IQueryable<T>, IOrderedQueryable<T>>? order = null) where T : EntityBase
        {
            if (order == null)
            {
                query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = order(query);
            }

            this.TotalCount = await query.CountAsync();
            var numberOfPages = this.TotalCount / PageSize;

            var skipAmount = (PageIndex - 1) * PageSize;

            var paginatedData = query
                .Skip(skipAmount)
                .Take(PageSize)
                .ToListAsync();

            return await paginatedData;
        }
    }
}
