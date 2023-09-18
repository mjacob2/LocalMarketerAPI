using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using System.Globalization;

namespace LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsRequest, GetAllClientsResponse>
    {
        private readonly IQueryExecutor executor;

        public GetAllClientsHandler(IQueryExecutor executor)
        {
            this.executor = executor;
        }
        public async Task<GetAllClientsResponse> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllClientsQuery()
            {
                ShowOnlyUnallocated = request.ShowOnlyUnallocaded,

                PageIndex = request.PageIndex,
                PageSize = request.PageSize,

                LoggedUserRole = request.LoggedUserRole,
                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),

            };

            var dataFromDb = await this.executor.Execute(query);

            var dataFromDbMappedToModel = ClientsMappings.GetAllClients(dataFromDb);

            var response = new GetAllClientsResponse()
            {
                ResponseData = dataFromDbMappedToModel,
                Count = query.TotalCount,
            };
            return response;
        }
    }
}
