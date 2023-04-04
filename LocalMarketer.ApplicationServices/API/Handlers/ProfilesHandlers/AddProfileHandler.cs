﻿using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using LocalMarketer.DataAccess.CQRS.Commands.ProfilesCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UserResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

namespace LocalMarketer.ApplicationServices.API.Handlers.ProfilesHandlers
{
        public class AddProfileHandler : IRequestHandler<AddProfileRequest, AddProfileResponse>
        {
                private readonly ICommandExecutor executor;
                private Profile dataFromDb;

                public AddProfileHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddProfileResponse> Handle(AddProfileRequest request, CancellationToken cancellationToken)
                {
                        // TODO dont let create Profile with the samename
                        var itemtoAdd = new Profile()
                        {
                                CreationDate = DateTime.Today,
                                Name = request.Name,
                                CreatorId = int.Parse(request.LoggedUserId),
                                UserId = 3, // Administrator
                                ClientId = request.ClientId,
                                Description = request.Description,
                        };

                        var command = new AddProfileCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddProfileResponse()
                                {
                                        Error = new ErrorModel(ErrorType.ProfileAlreadyExists),
                                };
                        }

                        var response = new AddProfileResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }
        }
}
