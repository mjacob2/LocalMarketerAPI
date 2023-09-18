using LocalMarketer.ApplicationServices.API.Domain.Models;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses
{
        /// <summary>
        /// Base for error responses.
        /// </summary>
        public class ErrorResponseBase
        {
                /// <summary>
                /// Gets or sets the <see cref="ErrorModel"/> object.
                /// </summary>
                public ErrorModel? Error { get; set; }
        }
}
