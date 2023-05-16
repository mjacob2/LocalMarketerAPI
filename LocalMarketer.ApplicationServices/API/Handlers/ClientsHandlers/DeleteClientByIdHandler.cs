using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers
{
        public class DeleteClientByIdHandler : IRequestHandler<DeleteClientByIdRequest, DeleteClientByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public DeleteClientByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<DeleteClientByIdResponse> Handle(DeleteClientByIdRequest request, CancellationToken cancellationToken)
                {
                        if (request.LoggedUserRole != User.Roles.Administrator.ToString())
                        {
                                return new DeleteClientByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }
                        var itemToDelete = new Client()
                        {
                                ClientId = request.ClientId,
                        };
                        var command = new DeleteClientByIdCommand() { Parameter = itemToDelete };

                        try
                        {
                                await this.commandExecutor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                        {
                                return new DeleteClientByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        return new DeleteClientByIdResponse()
                        {
                                ResponseData = request.ClientId,
                        };
                }
        }
}