using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;
namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests
{
    public class GetAllToDosRequest : PagedRequestBase, IRequest<GetAllToDosResponse>
    {
                public bool ShowOnlyUnfinished { get; set; }
                public bool ShowOnlyFinished { get; set; }
        }
}
