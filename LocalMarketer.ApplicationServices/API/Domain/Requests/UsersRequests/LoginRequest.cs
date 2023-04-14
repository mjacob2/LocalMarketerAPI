using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests
{
        public class LoginRequest : RequestBase, IRequest<LoginResponse>
        {
                public string Email { get; set; }
                public string Password { get; set; }
        }
}
