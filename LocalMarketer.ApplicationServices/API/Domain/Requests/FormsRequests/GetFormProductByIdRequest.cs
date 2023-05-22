using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;
namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class GetFormProductByIdRequest : RequestBase, IRequest<GetFormProductByIdResponse>
        {
                public int FormProductId { get; set; }
        }
}
