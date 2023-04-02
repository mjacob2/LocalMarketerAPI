using LocalMarketer.ApplicationServices.API.Domain.Requests;
using LocalMarketer.ApplicationServices.API.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [ApiController]
        public class ClientsController : ApiControllerBase
        {
                public ClientsController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("[controller]")]
                public Task<IActionResult> GetAllClients([FromQuery] GetAllClientsRequest request)
                {
                        return this.HandleRequest<GetAllClientsRequest, GetAllClientsResponse>(request);
                }
        }
}
