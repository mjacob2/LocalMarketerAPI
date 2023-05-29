using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.FormsCommands;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace LocalMarketer.ApplicationServices.API.Handlers.FormsHandlers
{
        internal class AddFormBasicHandler : IRequestHandler<AddFormBasicRequest, AddFormBasicResponse>
        {
                private readonly ICommandExecutor executor;
                private readonly IConfiguration configuration;
                private FormBasic dataFromDb;

                public AddFormBasicHandler(ICommandExecutor executor, IConfiguration configuration)
                {
                        this.executor = executor;
                        configuration = configuration;
                }

                public async Task<AddFormBasicResponse> Handle(AddFormBasicRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new FormBasic()
                        {
                                CreationDate = DateTime.Today,
                                ProfileId = request.ProfileId,

                                AcceptedPaymentMethods = request.AcceptedPaymentMethods,
                                Atr1 = request.Atr1,
                                Atr10 = request.Atr10,
                                Atr11 = request.Atr11,
                                Atr12 = request.Atr12,
                                Atr13 = request.Atr13,
                                Atr14 = request.Atr14,
                                Atr15 = request.Atr15,
                                Atr16 = request.Atr16,
                                Atr17 = request.Atr17,
                                Atr2 = request.Atr2,
                                Atr3 = request.Atr3,    
                                Atr4 = request.Atr4,
                                Atr5 = request.Atr5,    
                                Atr6 = request.Atr6,
                                Atr7 = request.Atr7,
                                Atr8 = request.Atr8,
                                Atr9 = request.Atr9,
                                City = request.City,
                                CustomerService = request.CustomerService,
                                DealId = request.DealId,
                                Description = request.Description,
                                FridayFrom = request.FridayFrom,
                                FridayTo = request.FridayTo,
                                MondayFrom = request.MondayFrom,
                                MondayTo = request.MondayTo,
                                OpenedDate = request.OpenedDate,
                                Phone = request.Phone,
                                PostCode = request.PostCode,
                                SaturdayFrom = request.SaturdayFrom,
                                SaturdayTo = request.SaturdayTo,
                                Street = request.Street,
                                SundayFrom = request.SundayFrom,
                                SundayTo = request.SundayTo,
                                ThursdayFrom = request.ThursdayFrom,
                                ThursdayTo = request.ThursdayTo,
                                TuesdayFrom = request.TuesdayFrom,
                                VisitsUrl = request.VisitsUrl,
                                Voivodeship = request.Voivodeship,
                                WebsiteUrl = request.WebsiteUrl,
                                WednesdayFrom = request.WednesdayFrom,
                                WednesdayTo = request.WednesdayTo,     
                        };

                        var command = new AddFormBasicCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);

                                await CreateAutomaticToDos(request.DealId, this.dataFromDb.FormBasicId);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddFormBasicResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }


                        var response = new AddFormBasicResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }

                private async Task CreateAutomaticToDos(int dealId, int formBasicId)
                {
                        var threeDaysFromNow = DateTime.Today.AddDays(3);

                        var todo = new ToDo()
                        {
                                DealId = dealId,
                                CreationDate = DateTime.Today,
                                CreatorId = 0,
                                Title = "Uzupełnij informacje podstawowe z formularza klienta",
                                DueDate = threeDaysFromNow,
                                Description = "",
                                IsFinished = false,
                                Notes = new List<Note>(),
                                Link1 = $"http://localhost:4200/formBasic/{formBasicId}",
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