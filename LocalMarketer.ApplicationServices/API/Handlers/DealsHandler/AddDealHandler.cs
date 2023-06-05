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
                                CreatorId = int.Parse(request.LoggedUserId),
                                CreationDate = DateTime.Today,
                                EndDate = DateTime.Today.AddMonths(request.SelectedPackage.DurationInMonths),
                                Stage = "In progress",

                                ProfileId = request.ProfileId,
                                Name = request.Name,
                                PackageId = request.SelectedPackage.PackageId,
                                Price = request.Price,
                                Description = request.Description,

                        };

                        var command = new AddDealCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddDealResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        try
                        {
                                await CreateAutomaticToDos(this.dataFromDb);
                        }
                        catch (Exception)
                        {
                                return new AddDealResponse()
                                {
                                        Error = new ErrorModel(ErrorType.AutomaticToDosError),
                                };
                        }

                        try
                        {
                                await EmailService.SendClientOnboardingEmail(this.dataFromDb, request.ProfileName, request.ClientEmail);
                        }

                        catch (Exception)
                        {
                                return new AddDealResponse()
                                {
                                        Error = new ErrorModel(ErrorType.AutomaticEmailError),
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
