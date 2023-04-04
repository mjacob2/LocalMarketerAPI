using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class ToDosController : ApiControllerBase
        {
                public ToDosController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("")]
                public Task<IActionResult> GetAllToDos([FromQuery] GetAllToDosRequest request)
                {
                        return this.HandleRequest<GetAllToDosRequest, GetAllToDosResponse>(request);
                }


                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddToDo([FromBody] AddToDoRequest request)
                {
                        return this.HandleRequest<AddToDoRequest, AddToDoResponse>(request);
                }
        }
}
