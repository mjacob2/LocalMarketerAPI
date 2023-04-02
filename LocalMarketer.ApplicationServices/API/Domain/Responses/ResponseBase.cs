namespace LocalMarketer.ApplicationServices.API.Domain.Responses
{
        /// <summary>
        /// Provides response body.
        /// </summary>
        /// <typeparam name="T">Type of response.</typeparam>
        public class ResponseBase<T> : ErrorResponseBase
        {
                public ResponseBase(T responseData)
                {
                        ResponseData = responseData;
                }

                /// <summary>
                /// Gets or sets data that is transmitted as a response.
                /// </summary>
                public T ResponseData { get; set; }
        }
}
