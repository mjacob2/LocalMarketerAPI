using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests
{
        public class GetAllProfilesRequest : PagedRequestBase, IRequest<GetAllProfilesResponse>
        {
        }
}
