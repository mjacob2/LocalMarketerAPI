using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UserResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class UsersController : ApiControllerBase
        {
                public UsersController(IMediator mediator) : base(mediator)
                {
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
                {
                        return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
                }

        }
}
