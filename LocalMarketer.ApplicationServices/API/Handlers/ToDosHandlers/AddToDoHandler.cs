using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

namespace LocalMarketer.ApplicationServices.API.Handlers.ToDosHandlers
{
        public class AddToDoHandler : IRequestHandler<AddToDoRequest, AddToDoResponse>
        {
                private readonly ICommandExecutor executor;
                private ToDo dataFromDb;

                public AddToDoHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddToDoResponse> Handle(AddToDoRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new ToDo()
                        {
                                //UserId = request.LoggedUserId
                                DealId = request.DealId,
                                CreationDate = DateTime.Today,
                                CreatorId = int.Parse(request.LoggedUserId),
                                Title = request.Title,
                                DueDate = request.DueDate,
                                Description = request.Description,
                                IsFinished = request.IsFinished,
                                Notes  = new List<Note>(),
                        };

                        var command = new AddToDoCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddToDoResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }


                        var response = new AddToDoResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }
        }
}
