using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.DealsCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;


namespace LocalMarketer.ApplicationServices.API.Handlers.DealsHandler
{
        public class AddDealHandler : IRequestHandler<AddDealRequest, AddDealResponse>
        {
                private readonly ICommandExecutor executor;
                private Deal dataFromDb;

                public AddDealHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddDealResponse> Handle(AddDealRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new Deal()
                        {
                                SellerFullName = request.SellerFullName,
                                SellerId = request.SellerId,
                                CreationDate = DateTime.Today,
                                Name = request.Name,
                                Price = request.Price,
                                CreatorId = int.Parse(request.LoggedUserId),
                                ProfileId = request.ProfileId,
                                PackageId = request.SelectedPackage.PackageId,
                                Description = request.Description,
                                EndDate = DateTime.Today.AddMonths(request.SelectedPackage.DurationInMonths),
                                Stage = "In progress",

                        };

                        var command = new AddDealCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);

                                await CreateAutomaticToDos(this.dataFromDb);

                                await EmailService.SendClientOnboardingEmail(this.dataFromDb, request.ProfileName);

                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddDealResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }



                        var response = new AddDealResponse()
                        {
                                ResponseData = this.dataFromDb,
                        };


                        return response;
                }

                private async Task CreateAutomaticToDos(Deal newDeal)
                {
                        List<ToDo> toDosToAdd = new AutomaticToDos(newDeal).GetTasks();

                        foreach (var toDo in toDosToAdd)
                        {
                                var command = new AddToDoCommand() { Parameter = toDo };
                                try
                                {
                                        await this.executor.Execute(command);
                                }
                                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                                {
                                        throw new InvalidOperationException(ex.Message);
                                }
                        }

                }

        }


}
