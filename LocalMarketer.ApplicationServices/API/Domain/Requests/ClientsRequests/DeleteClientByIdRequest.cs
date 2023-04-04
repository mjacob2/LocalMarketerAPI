using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class DeleteClientByIdRequest : RequestBase, IRequest<DeleteClientByIdResponse>
        {
                public int ClientId { get; set; }
        }
}
