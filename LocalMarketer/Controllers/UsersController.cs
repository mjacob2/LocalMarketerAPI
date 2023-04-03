using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        public class UsersController : ApiControllerBase
        {
                public ClientsController(IMediator mediator) : base(mediator)
                {
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("[controller]")]
                public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
                {
                        return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
                }

        }
}
