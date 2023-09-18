using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.ToDosHandlers
{
    public class UpdateToDoByIdHandler : IRequestHandler<UpdateToDoByIdRequest, UpdateToDoByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public UpdateToDoByIdHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public async Task<UpdateToDoByIdResponse> Handle(UpdateToDoByIdRequest request, CancellationToken cancellationToken)
        {
            var requestToDoMappedToEntity = new ToDo()
            {
                Id = request.ToDoId,
                DealId = request.ToDoId,
                Title = request.Title,
                DueDate = request.DueDate,
                Description = request.Description,
                IsFinished = request.IsFinished,
                ForRole = request.ForRole,
                Link1 = request.Link1,
                Link2 = request.Link2,
                Link3 = request.Link3,
                Link4 = request.Link4,
                Link5 = request.Link5,
            };

            if (request.IsFinished)
            {
                requestToDoMappedToEntity.ExecutionDate = DateTime.Today;
            }
            else
            {
                requestToDoMappedToEntity.ExecutionDate = null;
            }

            var command = new UpdateToDoCommand() { Parameter = requestToDoMappedToEntity };

            try
            {
                var updatedToDoResponse = await this.commandExecutor.Execute(command);

                //jesli seller zadanie ukończone to z dodaniem linka do mediów, to wtedy utwórz nowe zadanie dla drugiego uzytkownika przypisanego do klienta, ktory nie jest seller, żeby dodał te zdjęcia na profil

                if (updatedToDoResponse.Title == "Wklej link do folderu z mediami" && updatedToDoResponse.IsFinished)
                {
                    var newToDoForLocalMarketer = new ToDo()
                    {
                        DealId = request.DealId,
                        CreationDate = DateTime.Today,
                        CreatorId = 0,
                        Title = "Dodaj media z folderu podlinkowanego przez sprzedawcę",
                        DueDate = DateTime.Today.AddDays(3),
                        Description = "Utwórz jedno, reprezentacyjne zdjęcie jako zdjęcie główne z dekoracją. Jeśli nie ma filmu, utwórz prosty film (pokaz slajdów) ze zdjęć. Resztę zdjęć dodaj do profilu.",
                        IsFinished = false,
                        Notes = new List<Note>()
                                        {
                                                new Note()
                                                {
                                                        CreationDate = DateTime.Today,
                                                        Name = "",
                                                }
                                        },
                        ForRole = User.Roles.LocalMarketer.ToString(),
                    };

                    var command2 = new AddToDoCommand() { Parameter = newToDoForLocalMarketer };

                    try
                    {
                        await this.commandExecutor.Execute(command2);
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                }

                return new UpdateToDoByIdResponse()
                {
                    ResponseData = updatedToDoResponse,
                };
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                var responseWitherrorNotFound = new UpdateToDoByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound),
                };
                return responseWitherrorNotFound;
            }
        }
    }
}