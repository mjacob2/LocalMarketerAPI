using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class DeleteDealByIdRequest : RequestBase, IRequest<DeleteDealByIdResponse>
        {
                public int DealId { get; set; }
        }
}
