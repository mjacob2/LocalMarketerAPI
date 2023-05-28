using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.DealsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.DealsHandler
{
        public class GetAllDealsHandler : IRequestHandler<GetAllDealsRequest, GetAllDealsResponse>
        {
                private readonly IQueryExecutor executor;

                public GetAllDealsHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetAllDealsResponse> Handle(GetAllDealsRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllDealsQuery()
                        {
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),

                                PageIndex = request.PageIndex + 1,
                                PageSize = request.PageSize,
                        };
                        var dataFromDb = await this.executor.Execute(query);
                        var DataFromDbMappedToModel = DealsMappings.GetAllDeals(dataFromDb.Items);
                        var response = new GetAllDealsResponse()
                        {
                                ResponseData = DataFromDbMappedToModel,
                                Count = dataFromDb.Count,
                        };
                        return response;
                }
        }
}