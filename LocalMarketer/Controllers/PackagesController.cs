using LocalMarketer.ApplicationServices.API.Domain.Requests.PackagesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.PackagesResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class PackagesController : ApiControllerBase
        {
                public PackagesController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("")]
                public Task<IActionResult> GetAllPackages([FromQuery] GetAllPackagesRequest request)
                {
                        return this.HandleRequest<GetAllPackagesRequest, GetAllPackagesResponse>(request);
                }
        }
}
