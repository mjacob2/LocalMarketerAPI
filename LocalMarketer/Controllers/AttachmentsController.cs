using LocalMarketer.ApplicationServices.API.Domain.Requests.AttachmentsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.AttachmentsResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class AttachmentsController : ApiControllerBase
        {
                public AttachmentsController(IMediator mediator) : base(mediator)
                {

                }

                [HttpPost]
                [Route("")]

                public Task<IActionResult> AddAttachment([FromBody] AddAttachmentRequest request)
                {

                        return this.HandleRequest<AddAttachmentRequest, AddAttachmentResponse>(request);
                }
        }
}
