using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class GetAllDealsRequest : PagedRequestBase, IRequest<GetAllDealsResponse>
        {
        }
}