using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Commands.ClientsCommands;
using LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers
{
        public class AddClientHandler : IRequestHandler<AddClientRequest, AddClientResponse>
        {
                private readonly ICommandExecutor executor;

                public AddClientHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddClientResponse> Handle(AddClientRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new Client()
                        {
                                CreationDate = DateTime.Today,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                Phone = request.Phone,
                                Email = request.Email,
                                Source = request.Source,
                                Description = request.Description,
                                SellerEmail = request.SellerEmail,
                        };

                        var command = new AddClientCommand() { Parameter = itemtoAdd };

                        var dataFromDb = await this.executor.Execute(command);

                        var response = new AddClientResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }
        }
}
