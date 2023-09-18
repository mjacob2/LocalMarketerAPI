using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
    public class GetAllClientsRequest : PagedRequestBase, IRequest<GetAllClientsResponse>
    {
        /// <summary>
        /// Gets or sets value for filtering data for these only with no assigned LocalMarketer.
        /// </summary>
        public bool ShowOnlyUnallocaded { get; set; } = false;
    }
}
