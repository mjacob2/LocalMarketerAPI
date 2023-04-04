using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketer.Controllers
{
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class ProfilesController : ApiControllerBase
        {
                public ProfilesController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("")]
                public Task<IActionResult> GetAllProfiles([FromQuery] GetAllProfilesRequest request)
                {
                        return this.HandleRequest<GetAllProfilesRequest, GetAllProfilesResponse>(request);
                }

                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddProfile([FromBody] AddProfileRequest request)
                {
                        return this.HandleRequest<AddProfileRequest, AddProfileResponse>(request);
                }
        }
}
