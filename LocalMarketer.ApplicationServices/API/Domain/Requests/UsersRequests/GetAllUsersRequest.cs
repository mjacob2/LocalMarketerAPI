using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests
{
        public class GetAllUsersRequest : RequestBase, IRequest<GetAllUsersResponse>
        {
        }
}