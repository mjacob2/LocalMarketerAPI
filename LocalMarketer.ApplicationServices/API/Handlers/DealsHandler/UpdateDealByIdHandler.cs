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
        public class UpdateDealByIdHandler : IRequestHandler<UpdateDealByIdRequest, UpdateDealByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public UpdateDealByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<UpdateDealByIdResponse> Handle(UpdateDealByIdRequest request, CancellationToken cancellationToken)
                {
                        var DealMappedToEntity = new Deal()
                        {
                                DealId = request.DealId,
                                Name = request.Name,
                                Stage = request.Stage,
                                Description = request.Description,
                                Price = request.Price,
                                EndDate = request.EndDate,
                                PackageId = request.PackageId,
                        };
                        var command = new UpdateDealCommand() { Parameter = DealMappedToEntity };

                        try
                        {
                                var updatedDealResponse = await this.commandExecutor.Execute(command);

                                return new UpdateDealByIdResponse()
                                {
                                        ResponseData = updatedDealResponse,
                                };
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                        {
                                var responseWitherrorNotFound = new UpdateDealByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                                return responseWitherrorNotFound;
                        }
                }
        }
}