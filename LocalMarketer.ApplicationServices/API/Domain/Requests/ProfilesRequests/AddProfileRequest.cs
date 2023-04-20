using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests
{
        public class AddProfileRequest : RequestBase, IRequest<AddProfileResponse>
        {
                public string Name { get; set; }
                public int ClientId { get; set; }
                public string? Description { get; set; }

        }
}
