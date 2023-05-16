using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.ToDosHandlers
{
        public class UpdateToDoByIdHandler : IRequestHandler<UpdateToDoByIdRequest, UpdateToDoByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public UpdateToDoByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<UpdateToDoByIdResponse> Handle(UpdateToDoByIdRequest request, CancellationToken cancellationToken)
                {
                        var ToDoMappedToEntity = new ToDo()
                        {
                                ToDoId = request.ToDoId,
                                Title = request.Title,
                                DueDate = request.DueDate,
                                Description = request.Description,
                                IsFinished = request.IsFinished,
                        };
                        var command = new UpdateToDoCommand() { Parameter = ToDoMappedToEntity };

                        try
                        {
                                var updatedToDoResponse = await this.commandExecutor.Execute(command);

                                return new UpdateToDoByIdResponse()
                                {
                                        ResponseData = updatedToDoResponse,
                                };
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                        {
                                var responseWitherrorNotFound = new UpdateToDoByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                                return responseWitherrorNotFound;
                        }
                }
        }
}