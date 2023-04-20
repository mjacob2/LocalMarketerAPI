
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class UpdateClientByIdRequest : RequestBase, IRequest<UpdateClientByIdResponse>
        {
                public int ClientId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string Source { get; set; } = string.Empty;
                public string Description { get; set; } = string.Empty;
        }
}
