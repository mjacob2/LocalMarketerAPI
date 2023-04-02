using LocalMarketer.ApplicationServices.API.Domain.Requests;
using LocalMarketer.ApplicationServices.API.Domain.Responses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries;
using MediatR;
using System.Globalization;


namespace LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers
{
        public class GetAllClientsHandler : IRequestHandler<GetAllClientsRequest, GetAllClientsResponse>
        {
                private readonly IQueryExecutor queryExecutor;

                public GetAllClientsHandler(IQueryExecutor queryExecutor)
                {
                        this.queryExecutor = queryExecutor;
                }
                public async Task<GetAllClientsResponse> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllClientsQuery()
                        {
                                //LoggedUserRole = request.LoggedUserRole,
                                //LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var DataFromDb = await this.queryExecutor.Execute(query);
                        var DataFromDbMappedtoModel = ClientsMapping.GetAllClients(DataFromDb);
                        var response = new GetAllClientsResponse(DataFromDbMappedtoModel);

                        return response;
                }
        }
}
