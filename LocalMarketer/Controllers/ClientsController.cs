using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class ClientsController : ApiControllerBase
        {
                public ClientsController(IMediator mediator) : base(mediator)
                {
                }


                [HttpGet]
                [Route("")]
                public Task<IActionResult> GetAllClients([FromQuery] GetAllClientsRequest request)
                {
                        return this.HandleRequest<GetAllClientsRequest, GetAllClientsResponse>(request);
                }

                [HttpGet]
                [Route("{id}")]
                public Task<IActionResult> GetClientById([FromRoute] int id)
                {
                        var request = new GetClientByIdRequest()
                        {
                                Id = id,
                        };
                        return this.HandleRequest<GetClientByIdRequest, GetClientByIdResponse>(request);
                }

                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddClient([FromBody] AddClientRequest request)
                {
                        return this.HandleRequest<AddClientRequest, AddClientResponse>(request);
                }
        }
}
