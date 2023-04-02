using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
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

                [HttpPost]
                [Route("[controller]")]
                public Task<IActionResult> AddClient([FromBody] AddClientRequest request)
                {
                        return this.HandleRequest<AddClientRequest, AddClientResponse>(request);
                }
        }
}
