using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class AddClientRequest : RequestBase, IRequest<AddClientResponse>
        {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string Voivodeship { get; set; }
                public string City { get; set; }
                public string Street { get; set; }
                public string PostCode { get; set; }
                public string Source { get; set; }
                public string Description { get; set; } = string.Empty;
                public string SellerEmail { get; set; }
        }
}
