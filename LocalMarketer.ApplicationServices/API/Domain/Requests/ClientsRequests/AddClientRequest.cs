using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class AddClientRequest : RequestBase, IRequest<AddClientResponse>
        {
                public string Name { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string Source { get; set; }
                public string Description { get; set; } = string.Empty;
                public int SellerId { get; set; }
        }
}
