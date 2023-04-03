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
                public string LoggedUserId { get; set; } = string.Empty;
                public string LoggedUserRole { get; set; } = string.Empty;
        }
}
