using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests
{
        public class GetAllProfilesRequest : RequestBase, IRequest<GetAllProfilesResponse>
        {
                public int PageIndex { get; set; }
                public int PageSize { get; set; }
        }
}
