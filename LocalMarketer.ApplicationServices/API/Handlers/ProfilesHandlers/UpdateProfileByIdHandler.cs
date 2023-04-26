﻿using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Commands.ProfilesCommands;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using Newtonsoft.Json.Linq;
using static LocalMarketer.DataAccess.Entities.Profile;

namespace LocalMarketer.ApplicationServices.API.Handlers.ProfilesHandlers
{
        public class UpdateProfileByIdHandler : IRequestHandler<UpdateProfileByIdRequest, UpdateProfileByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                /// <summary>
                /// Initializes a new instance of the <see cref="UpdateProfileByIdHandler"/> class.
                /// </summary>
                /// <param name="commandExecutor">The command executor.</param>
                public UpdateProfileByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                /// <summary>
                /// Handles the.
                /// </summary>
                /// <param name="request">The request.</param>
                /// <param name="cancellationToken">The cancellation token.</param>
                /// <returns>A Task.</returns>
                public async Task<UpdateProfileByIdResponse> Handle(UpdateProfileByIdRequest request, CancellationToken cancellationToken)
                {
                        var profileMappedToEntity = new Profile()
                        {
                                Id = request.ProfileId,
                                GoogleProfileId = request.GoogleProfileId,
                                Name = request.Name,
                                UserId = request.UserId,
                                ClientId = request.ClientId,
                                WebsiteUrl = request.WebsiteUrl,
                                ProfileUrl = request.ProfileUrl,
                                Voivodeship = request.Voivodeship,
                                City = request.City,
                                Street = request.Street,
                                PostCode = request.PostCode,
                                NIP = request.NIP,
                                REGON = request.REGON,
                                Email = request.Email,
                                Phone = request.Phone,
                                Source = request.Source,
                                Description = request.Description,
                                CustomerService = request.CustomerService,
                        };
                        var command = new UpdateProfileCommand() { Parameter = profileMappedToEntity };

                        try
                        {
                                var updatedProfileResponse = await this.commandExecutor.Execute(command);

                                return new UpdateProfileByIdResponse()
                                {
                                        ResponseData = updatedProfileResponse,
                                };
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                        {
                                var responseWitherrorNotFound = new UpdateProfileByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.GoogleIdAlreadyExists),
                                };
                                return responseWitherrorNotFound;
                        }
                }
        }
}