using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.FormsCommands;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.FormsHandlers
{
        internal class AddFormServiceHandler : IRequestHandler<AddFormServiceRequest, AddFormServiceResponse>
        {
                private readonly ICommandExecutor executor;
                private FormService dataFromDb;

                public AddFormServiceHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddFormServiceResponse> Handle(AddFormServiceRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new FormService()
                        {
                                CreationDate = DateTime.Today,
                                ProfileId = request.ProfileId,
                                Services = request.Services,
                        };

                        var command = new AddFormServiceCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);

                                await CreateAutomaticToDos(request.DealId, this.dataFromDb.FormServiceId);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddFormServiceResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }


                        var response = new AddFormServiceResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }

                private async Task CreateAutomaticToDos(int dealId, int formServiceId)
                {
                        var threeDaysFromNow = DateTime.Today.AddDays(3);

                        var todo = new ToDo()
                        {
                                DealId = dealId,
                                CreationDate = DateTime.Today,
                                CreatorId = 0,
                                Title = "Uzupełnij Usługi z formularza klienta",
                                DueDate = threeDaysFromNow,
                                Description = "",
                                IsFinished = false,
                                Notes = new List<Note>(),
                                Link1 = $"http://localhost:4200/formService/{formServiceId}",
                                ForRole = User.Roles.LocalMarketer.ToString(),
                        };


                        var command = new AddToDoCommand() { Parameter = todo };
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