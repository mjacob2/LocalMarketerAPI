using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class GetDealByIdRequest : RequestBase, IRequest<GetDealByIdResponse>
        {
                public int DealId { get; set; }
        }
}