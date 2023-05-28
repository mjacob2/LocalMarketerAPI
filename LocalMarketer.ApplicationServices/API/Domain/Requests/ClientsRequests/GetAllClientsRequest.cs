using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
    public class GetAllClientsRequest : RequestBase, IRequest<GetAllClientsResponse>
    {
                public bool ShowOnlyUnallocaded { get; set; }
                public int PageIndex { get; set; }
                public int PageSize { get; set; }
        }
}
