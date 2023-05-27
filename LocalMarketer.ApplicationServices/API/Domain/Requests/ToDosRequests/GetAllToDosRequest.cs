using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;
namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests
{
    public class GetAllToDosRequest : RequestBase, IRequest<GetAllToDosResponse>
    {
                public bool ShowOnlyUnfinished { get; set; }

                public bool ShowOnlyFinished { get; set; }

                public int PageIndex { get; set; }

                public int PageSize { get; set; }

        }
}
