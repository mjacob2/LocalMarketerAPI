using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests
{
        public class GetProfileByIdAnonymousRequest : RequestBase, IRequest<GetProfileByIdAnonymousResponse>
        {
                public int ProfileId { get; set; }
        }
}