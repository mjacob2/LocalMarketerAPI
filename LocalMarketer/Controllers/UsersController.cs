using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        public class UsersController : ApiControllerBase
        {
                public UsersController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("users")]
                public Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
                {
                        return this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
                }

                [HttpPost]
                [Route("users/addUser")]
                public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
                {
                        return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("login")]
                public Task<IActionResult> Login([FromBody] LoginRequest request)
                {
                        return this.HandleRequest<LoginRequest, LoginResponse>(request);
                }

        }
}
