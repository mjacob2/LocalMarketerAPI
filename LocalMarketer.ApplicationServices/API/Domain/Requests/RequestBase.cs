namespace LocalMarketer.ApplicationServices.API.Domain.Requests
{
        /// <summary>
        /// Provides base request to handle claims.
        /// </summary>
        public class RequestBase
        {
                /// <summary>
                /// Gets or sets currently logged user id.
                /// </summary>
                public string LoggedUserId { get; set; } = string.Empty;

                /// <summary>
                /// Gets or sets the logged user role.
                /// </summary>
                public string LoggedUserRole { get; set; } = string.Empty;

                /// <summary>
                /// Gets or sets the logged user full name.
                /// </summary>
                public string LoggedUserFullName {get;  set; } = string.Empty;
        }
}
