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
                                ClientId = id,
                        };
                        return this.HandleRequest<GetClientByIdRequest, GetClientByIdResponse>(request);
                }

                [HttpPut]
                [Route("{id}")]
                public Task<IActionResult> UpdateClientById([FromRoute] int id, [FromBody] UpdateClientByIdRequest request)
                {
                        request.ClientId = id;

                        return this.HandleRequest<UpdateClientByIdRequest, UpdateClientByIdResponse>(request);
                }

                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddClient([FromBody] AddClientRequest request)
                {
                        return this.HandleRequest<AddClientRequest, AddClientResponse>(request);
                }

                [HttpDelete]
                [Route("{id}")]
                public Task<IActionResult> DeteleClientById([FromRoute] int id)
                {
                        var request = new DeleteClientByIdRequest()
                        {
                                ClientId = id,
                        };

                        return this.HandleRequest<DeleteClientByIdRequest, DeleteClientByIdResponse>(request);
                }
        }
}
