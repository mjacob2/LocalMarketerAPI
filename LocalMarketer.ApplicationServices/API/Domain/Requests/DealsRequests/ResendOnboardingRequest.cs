using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class ResendOnboardingRequest : RequestBase, IRequest<ResendOnboardingResponse>
        {
                public int DealId { get; set; }
                public int ProfileId { get; set; }
                public string ClientEmail { get; set; }
        }
}
