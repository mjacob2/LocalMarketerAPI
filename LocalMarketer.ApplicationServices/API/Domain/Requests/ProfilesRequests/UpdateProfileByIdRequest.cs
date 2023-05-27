using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;
using static LocalMarketer.DataAccess.Entities.Profile;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests
{
        public class UpdateProfileByIdRequest : RequestBase, IRequest<UpdateProfileByIdResponse>
        {
                public int ProfileId { get; set; }
                public int ClientId { get; set; }
                public string Name { get; set; }
                public string Voivodeship { get; set; }
                public string City { get; set; }
                public string? Street { get; set; }
                public string? PostCode { get; set; }
                public string? Phone { get; set; }
                public string? CustomerService { get; set; }
                public string? WebsiteUrl { get; set; }
                public string? GoogleProfileId { get; set; }
                public string? Description { get; set; }
                public string? ProfileUrl { get; set; }
                public string? MediaLink { get; set; }
        }
}
