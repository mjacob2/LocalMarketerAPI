
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class UpdateClientByIdRequest : RequestBase, IRequest<UpdateClientByIdResponse>
        {
                public int ClientId { get; set; }
                public string Name { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }

                public string? Description { get; set; }
                public string? GoogleGroupId { get; set; }
                public List<ClientUser> ClientUsers { get; set; }
        }
}
