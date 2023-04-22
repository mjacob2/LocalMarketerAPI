using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class DealsController : ApiControllerBase
        {
                public DealsController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("")]
                public Task<IActionResult> GetAllDeals([FromQuery] GetAllDealsRequest request)
                {
                        return this.HandleRequest<GetAllDealsRequest, GetAllDealsResponse>(request);
                }

        }
}
