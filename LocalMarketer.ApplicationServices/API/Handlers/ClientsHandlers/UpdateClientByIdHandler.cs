using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers
{
        public class UpdateClientByIdHandler : IRequestHandler<UpdateClientByIdRequest, UpdateClientByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                /// <summary>
                /// Initializes a new instance of the <see cref="UpdateClientByIdHandler"/> class.
                /// </summary>
                /// <param name="commandExecutor">The command executor.</param>
                public UpdateClientByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                /// <summary>
                /// Handles the.
                /// </summary>
                /// <param name="request">The request.</param>
                /// <param name="cancellationToken">The cancellation token.</param>
                /// <returns>A Task.</returns>
                public async Task<UpdateClientByIdResponse> Handle(UpdateClientByIdRequest request, CancellationToken cancellationToken)
                {
                        var clientMappedToEntity = new Client()
                        {
                                Id = request.ClientId,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                Email = request.Email,
                                Phone = request.Phone,
                                Source = request.Source,
                                Description = request.Description,
                        };
                        var command = new UpdateClientCommand() { Parameter = clientMappedToEntity };

                        try
                        {
                                var updatedClientResponse = await this.commandExecutor.Execute(command);

                                return new UpdateClientByIdResponse()
                                {
                                        ResponseData = updatedClientResponse,
                                };
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                        {
                                var responseWitherrorNotFound = new UpdateClientByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                                return responseWitherrorNotFound;
                        }
                }
        }
}