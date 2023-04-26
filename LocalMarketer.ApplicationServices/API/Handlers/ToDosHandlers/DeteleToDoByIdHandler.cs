using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.ToDosHandlers
{
        public class DeteleToDoByIdHandler : IRequestHandler<DeleteToDoByIdRequest, DeleteToDoByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public DeteleToDoByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<DeleteToDoByIdResponse> Handle(DeleteToDoByIdRequest request, CancellationToken cancellationToken)
                {
                        if (request.LoggedUserRole != User.Roles.Administrator.ToString())
                        {
                                return new DeleteToDoByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }
                        var itemToDelete = new ToDo()
                        {
                                Id = request.ToDoId,
                        };
                        var command = new DeleteToDoByIdCommand() { Parameter = itemToDelete };

                        try
                        {
                                await this.commandExecutor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                        {
                                return new DeleteToDoByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        return new DeleteToDoByIdResponse()
                        {
                                ResponseData = request.ToDoId,
                        };
                }
        }
}