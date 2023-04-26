using LocalMarketer.ApplicationServices.API.Domain.Requests.PackagesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.PackagesResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.PackagesQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.PackagesHandlers
{
        public class GetAllPackagesHandler : IRequestHandler<GetAllPackagesRequest, GetAllPackagesResponse>
        {
                private readonly IQueryExecutor executor;

                public GetAllPackagesHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetAllPackagesResponse> Handle(GetAllPackagesRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllPackagesQuery()
                        {
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);
                        var response = new GetAllPackagesResponse()
                        {
                                ResponseData = dataFromDb,
                        };
                        return response;
                }
        }
}