using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using MediatR;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests
{
        public class AddUserRequest : RequestBase, IRequest<AddUserResponse>
        {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
                public string Password { get; set; }
                public string Role { get; set; }
        }
}
