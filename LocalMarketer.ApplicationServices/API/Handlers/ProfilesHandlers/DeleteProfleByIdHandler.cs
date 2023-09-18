using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.ProfilesCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.ProfilesHandlers
{
    public class DeleteProfleByIdHandler : IRequestHandler<DeleteProfileByIdRequest, DeleteProfileByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteProfleByIdHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteProfileByIdResponse> Handle(DeleteProfileByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.LoggedUserRole != User.Roles.Administrator.ToString())
            {
                return new DeleteProfileByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized),
                };
            }
            var itemToDelete = new Profile()
            {
                Id = request.ProfileId,
            };
            var command = new DeleteProfileByIdCommand() { Parameter = itemToDelete };

            try
            {
                await this.commandExecutor.Execute(command);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                return new DeleteProfileByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound),
                };
            }

            return new DeleteProfileByIdResponse()
            {
                ResponseData = request.ProfileId,
            };
        }
    }
}