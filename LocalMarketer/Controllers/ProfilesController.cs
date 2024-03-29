﻿using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
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

                [HttpGet]
                [Route("{id}")]
                public Task<IActionResult> GetProfileById([FromRoute] int id)
                {
                        var request = new GetProfileByIdRequest()
                        {
                                ProfileId = id,
                        };
                        return this.HandleRequest<GetProfileByIdRequest, GetProfileByIdResponse>(request);
                }

                [AllowAnonymous]
                [HttpGet]
                [Route("anonymous")]
                public Task<IActionResult> GetProfileByIdAnonymous([FromQuery] GetProfileByIdAnonymousRequest request)
                {
                        return this.HandleRequest<GetProfileByIdAnonymousRequest, GetProfileByIdAnonymousResponse>(request);
                }

                [AllowAnonymous]
                [HttpPut]
                [Route("{profileId}")]
                public Task<IActionResult> UpdateProfileById([FromRoute] int profileId, [FromBody] UpdateProfileByIdRequest request)
                {
                        request.ProfileId = profileId;

                        return this.HandleRequest<UpdateProfileByIdRequest, UpdateProfileByIdResponse>(request);
                }

                [HttpDelete]
                [Route("{id}")]
                public Task<IActionResult> DeteleProfileById([FromRoute] int id)
                {
                        var request = new DeleteProfileByIdRequest()
                        {
                                ProfileId = id,
                        };

                        return this.HandleRequest<DeleteProfileByIdRequest, DeleteProfileByIdResponse>(request);
                }

        }
}
