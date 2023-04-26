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

                [HttpGet]
                [Route("{id}")]
                public Task<IActionResult> GetDealById([FromRoute] int id)
                {
                        var request = new GetDealByIdRequest()
                        {
                                DealId = id,
                        };
                        return this.HandleRequest<GetDealByIdRequest, GetDealByIdResponse>(request);
                }

                [HttpPut]
                [Route("{id}")]
                public Task<IActionResult> UpdateDealById([FromRoute] int id, [FromBody] UpdateDealByIdRequest request)
                {
                        request.Id = id;

                        return this.HandleRequest<UpdateDealByIdRequest, UpdateDealByIdResponse>(request);
                }

                [HttpDelete]
                [Route("{id}")]
                public Task<IActionResult> DeteleDealById([FromRoute] int id)
                {
                        var request = new DeleteDealByIdRequest()
                        {
                                DealId = id,
                        };

                        return this.HandleRequest<DeleteDealByIdRequest, DeleteDealByIdResponse>(request);
                }

                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddDeal([FromBody] AddDealRequest request)
                {
                        return this.HandleRequest<AddDealRequest, AddDealResponse>(request);
                }

        }
}
