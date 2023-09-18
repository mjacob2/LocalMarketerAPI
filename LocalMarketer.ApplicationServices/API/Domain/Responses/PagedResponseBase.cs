using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses
{
    public class PagedResponseBase<T> : ResponseBase<T>
    {
        /// <summary>
        /// Gets or sets the count of all items in database.
        /// </summary>
        public int Count { get; set; }
    }
}
