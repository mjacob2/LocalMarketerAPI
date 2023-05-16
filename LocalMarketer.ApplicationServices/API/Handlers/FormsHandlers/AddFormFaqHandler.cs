using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.DataAccess.CQRS.Commands.FormsCommands;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;

namespace LocalMarketer.ApplicationServices.API.Handlers.FormsHandlers
{
        public class AddFormFaqHandler : IRequestHandler<AddFormFaqRequest, AddFormFaqResponse>
        {
                private readonly ICommandExecutor executor;
                private FormFaq dataFromDb;

                public AddFormFaqHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddFormFaqResponse> Handle(AddFormFaqRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new FormFaq()
                        {
                                CreationDate = DateTime.Today,

                                ProfileId = request.ProfileId,

                                Question1 = request.Question1,
                                Question2 = request.Question2,
                                Question3 = request.Question3,
                                Question4 = request.Question4,
                                Question5 = request.Question5,
                                Question6 = request.Question6,

                                Answer1 = request.Answer1,
                                Answer2 = request.Answer2,
                                Answer3 = request.Answer3,
                                Answer4 = request.Answer4,
                                Answer5 = request.Answer5,
                                Answer6 = request.Answer6,

                        };

                        var command = new AddFormFaqCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);

                                await CreateAutomaticToDos(request.DealId, this.dataFromDb.FormFaqId);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddFormFaqResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }


                        var response = new AddFormFaqResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }

                private async Task CreateAutomaticToDos(int dealId, int formFaqId)
                {
                        var threeDaysFromNow = DateTime.Today.AddDays(3);

                        var todo = new ToDo()
                        {
                                DealId = dealId,
                                CreationDate = DateTime.Today,
                                CreatorId = 0,
                                Title = "Uzupełnij FAQ z formularza klienta",
                                DueDate = threeDaysFromNow,
                                Description = "",
                                IsFinished = false,
                                Notes = new List<Note>(),
                                Link1 = $"http://localhost:4200/formfaq/{formFaqId}",
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