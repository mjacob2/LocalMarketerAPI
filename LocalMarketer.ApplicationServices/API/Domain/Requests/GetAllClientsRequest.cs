using LocalMarketer.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests
{
        public class GetAllClientsRequest : RequestBase, IRequest<GetAllClientsResponse>
        {
        }
}
