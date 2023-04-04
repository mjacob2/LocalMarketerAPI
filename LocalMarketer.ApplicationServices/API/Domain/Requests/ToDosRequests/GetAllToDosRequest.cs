using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;
namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests
{
    public class GetAllToDosRequest : RequestBase, IRequest<GetAllToDosResponse>
    {
    }
}
