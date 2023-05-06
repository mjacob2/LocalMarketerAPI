using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class FormFaqController : ApiControllerBase
        {
                public FormFaqController(IMediator mediator) : base(mediator)
                {
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddFormFaq([FromBody] AddFormFaqRequest request)
                {
                        return this.HandleRequest<AddFormFaqRequest, AddFormFaqResponse>(request);
                }

                [HttpGet]
                [Route("{id}")]
                public Task<IActionResult> GetFormFaqbyId([FromRoute] int id)
                {
                        var request = new GetFormFaqByIdRequest()
                        {
                                FormFaqId = id,
                        };
                        return this.HandleRequest<GetFormFaqByIdRequest, GetFormFaqByIdResponse>(request);
                }
        }
}
