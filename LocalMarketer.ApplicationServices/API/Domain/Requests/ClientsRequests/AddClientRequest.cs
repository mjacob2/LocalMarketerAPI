using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class AddClientRequest : RequestBase, IRequest<AddClientResponse>
        {
                public string Name { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public int SellerId { get; set; }
                public string? Description { get; set; }
                
        }
}
