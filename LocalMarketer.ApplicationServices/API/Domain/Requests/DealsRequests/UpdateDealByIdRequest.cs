using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class UpdateDealByIdRequest : RequestBase, IRequest<UpdateDealByIdResponse>
        {
                public int DealId { get; set; }
                public string Name { get; set; }
                public string Stage { get; set; }
                public string Description { get; set; }
                public double Price { get; set; }
                public DateTime EndDate { get; set; }

        }
}
