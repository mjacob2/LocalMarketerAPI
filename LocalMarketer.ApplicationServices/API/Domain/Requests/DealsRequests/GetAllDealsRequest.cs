using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class GetAllDealsRequest : RequestBase, IRequest<GetAllDealsResponse>
        {
                public int PageIndex { get; set; }
                public int PageSize { get; set; }
        }
}