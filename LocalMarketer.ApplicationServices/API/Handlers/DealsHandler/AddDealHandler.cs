using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.DealsCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                CreationDate = DateTime.Today,
                                Name = request.Name,
                                Price = request.Price,
                                CreatorId = int.Parse(request.LoggedUserId),
                                ProfileId = request.ProfileId,
                                PackageId = request.PackageId,
                                Description = request.Description,
                                EndDate = request.EndDate,
                                Stage = request.Stage,
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
                                        Error = new ErrorModel(ErrorType.GoogleIdAlreadyExists),
                                };
                        }

                        var response = new AddDealResponse()
                        {
                                ResponseData = this.dataFromDb,
                        };

                        return response;
                }
        }
}
