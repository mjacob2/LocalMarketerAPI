using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Queries
{
    public abstract class QueryBase
    {
        /// <summary>
        /// Gets or sets the logged user id.
        /// </summary>
        public int LoggedUserId { get; set; }
        public string? LoggedUserRole { get; set; }
    }
}
