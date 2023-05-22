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
        public class FormsController : ApiControllerBase
        {
                public FormsController(IMediator mediator) : base(mediator)
                {
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("faq")]
                public Task<IActionResult> AddFormFaq([FromBody] AddFormFaqRequest request)
                {
                        return this.HandleRequest<AddFormFaqRequest, AddFormFaqResponse>(request);
                }

                [HttpGet]
                [Route("faq/{id}")]
                public Task<IActionResult> GetFormFaqbyId([FromRoute] int id)
                {
                        var request = new GetFormFaqByIdRequest()
                        {
                                FormFaqId = id,
                        };
                        return this.HandleRequest<GetFormFaqByIdRequest, GetFormFaqByIdResponse>(request);
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("service")]
                public Task<IActionResult> AddFormServices([FromBody] AddFormServiceRequest request)
                {
                        return this.HandleRequest<AddFormServiceRequest, AddFormServiceResponse>(request);
                }

                [HttpGet]
                [Route("service/{id}")]
                public Task<IActionResult> GetFormServiceById([FromRoute] int id)
                {
                        var request = new GetFormServiceByIdRequest()
                        {
                                FormServiceId = id,
                        };
                        return this.HandleRequest<GetFormServiceByIdRequest, GetFormServiceByIdResponse>(request);
                }

                [AllowAnonymous]
                [HttpPost]
                [Route("product")]
                public Task<IActionResult> AddFormProduct([FromBody] AddFormProductRequest request)
                {
                        return this.HandleRequest<AddFormProductRequest, AddFormProductResponse>(request);
                }

                [HttpGet]
                [Route("product/{id}")]
                public Task<IActionResult> GetFormProductById([FromRoute] int id)
                {
                        var request = new GetFormProductByIdRequest()
                        {
                                FormProductId = id,
                        };
                        return this.HandleRequest<GetFormProductByIdRequest, GetFormProductByIdResponse>(request);
                }
        }
}
