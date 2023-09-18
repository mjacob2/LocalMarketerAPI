namespace LocalMarketer.ApplicationServices.API.Domain.Requests
{
    public class PagedRequestBase : RequestBase
    {
        private static readonly int defaultPageIndex = 1;
        private static readonly int defaultPagesize = 10;

        /// <summary>
        /// Gets or sets index of page with requested result data.
        /// </summary>
        public int PageIndex { get; set; } = defaultPageIndex;

        /// <summary>
        /// Gets or sets number of items per size.
        /// </summary>
        public int PageSize { get; set; } = defaultPagesize;
    }
}
