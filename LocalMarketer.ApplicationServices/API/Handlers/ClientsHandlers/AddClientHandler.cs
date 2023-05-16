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
        public class AddClientHandler : IRequestHandler<AddClientRequest, AddClientResponse>
        {
                private readonly ICommandExecutor executor;
                private Client dataFromDb;

                public AddClientHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddClientResponse> Handle(AddClientRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new Client()
                        {
                                CreationDate = DateTime.Today,
                                Name = request.Name,
                                GoogleGroupId = string.Empty,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                Phone = request.Phone,
                                Email = request.Email,
                                Source = request.Source,
                                Description = request.Description,
                                CreatorId = int.Parse(request.LoggedUserId),
                                SellerId = request.SellerId,
                        };

                        var command = new AddClientCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddClientResponse()
                                {
                                        Error = new ErrorModel(ErrorType.ClientAlreadyExists),
                                };
                        }

                        var response = new AddClientResponse()
                        {
                                ResponseData = this.dataFromDb,
                        };

                        return response;
                }
        }
}
