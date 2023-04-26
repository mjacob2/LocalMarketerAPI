using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Queries.DealsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocalMarketer.DataAccess.Entities.User;
using LocalMarketer.ApplicationServices.Mappings;

namespace LocalMarketer.ApplicationServices.API.Handlers.DealsHandler
{
        public class GetDealByIdHandler : IRequestHandler<GetDealByIdRequest, GetDealByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetDealByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetDealByIdResponse> Handle(GetDealByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetDealByIdQuery()
                        {
                                DealId = request.DealId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetDealByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        if (request.LoggedUserRole == Roles.Seller.ToString()
                                && dataFromDb.CreatorId.ToString() != request.LoggedUserId)
                        {
                                return new GetDealByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }

                        var DataFromDbMappedToModel = DealsMappings.GetDealById(dataFromDb);

                        var response = new GetDealByIdResponse()
                        {
                                ResponseData = DataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}