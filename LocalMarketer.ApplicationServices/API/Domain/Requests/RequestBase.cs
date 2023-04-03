using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests
{
        /// <summary>
        /// Provides base request to handle claims.
        /// </summary>
        public class RequestBase
        {
                /// <summary>
                /// Gets or sets currently logged use id.
                /// </summary>
                public string LoggedUserId { get; set; }
                public string LoggedUserRole { get; set; }
        }
}
