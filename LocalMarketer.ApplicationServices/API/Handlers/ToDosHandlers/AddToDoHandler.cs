using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;

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
                                CreationDate = DateTime.Today,
                                CreatorId = int.Parse(request.LoggedUserId),
                                Title = request.Title,
                                StartDate = request.StartDate,
                                DueDate = request.DueDate,
                                Description = request.Description,
                                IsFinished = request.IsFinished,
                                Notes = request.Notes,
                        };

                        var command = new AddToDoCommand() { Parameter = itemtoAdd };

                        this.dataFromDb = await this.executor.Execute(command);

                        var response = new AddToDoResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }
        }
}
