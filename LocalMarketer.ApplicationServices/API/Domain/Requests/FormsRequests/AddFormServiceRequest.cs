using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class AddFormServiceRequest : RequestBase, IRequest<AddFormServiceResponse>
        {
                public int ProfileId { get; set; }
                public int DealId { get; set; }
                public List<Service>? Services { get; set; }
        }
}
