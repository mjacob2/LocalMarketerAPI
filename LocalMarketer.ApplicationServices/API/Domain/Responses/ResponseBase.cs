namespace LocalMarketer.ApplicationServices.API.Domain.Responses
{
        /// <summary>
        /// Provides response body.
        /// </summary>
        /// <typeparam name="T">Type of response.</typeparam>
        public class ResponseBase<T> : ErrorResponseBase
        {
                /// <summary>
                /// Gets or sets data that is transmitted as a response.
                /// </summary>
                public T? ResponseData { get; set; }
        }
}
