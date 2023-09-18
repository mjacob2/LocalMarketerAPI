using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.DealsCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.DealsHandler
{
    public class DeleteDealByIdHandler : IRequestHandler<DeleteDealByIdRequest, DeleteDealByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteDealByIdHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteDealByIdResponse> Handle(DeleteDealByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.LoggedUserRole != User.Roles.Administrator.ToString())
            {
                return new DeleteDealByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized),
                };
            }
            var itemToDelete = new Deal()
            {
                Id = request.DealId,
            };
            var command = new DeleteDealByIdCommand() { Parameter = itemToDelete };

            try
            {
                await this.commandExecutor.Execute(command);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                return new DeleteDealByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound),
                };
            }

            return new DeleteDealByIdResponse()
            {
                ResponseData = request.DealId,
            };
        }
    }
}