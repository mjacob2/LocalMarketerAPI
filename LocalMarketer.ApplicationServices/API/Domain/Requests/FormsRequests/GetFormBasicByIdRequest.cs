using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class GetFormBasicByIdRequest : RequestBase, IRequest<GetFormBasicByIdResponse>
        {
                public int FormBasicId { get; set; }
        }
}
