namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        /// <summary>
        /// Model for error.
        /// </summary>
        public class ErrorModel
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="ErrorModel"/> class.
                /// </summary>
                /// <param name="error">Error details.</param>
                public ErrorModel(string error)
                {
                        this.Error = error;
                }

                /// <summary>
                /// Gets the error.
                /// </summary>
                public string Error { get; }
        }
}
