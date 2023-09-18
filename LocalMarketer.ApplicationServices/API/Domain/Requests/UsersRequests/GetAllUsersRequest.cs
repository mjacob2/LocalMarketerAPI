using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests
{
    public class GetAllUsersRequest : PagedRequestBase, IRequest<GetAllUsersResponse>
    {
        public bool? ShowOnlySellers { get; set; }
    }
}