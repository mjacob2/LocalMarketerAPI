using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries;
using MediatR;
using System.Globalization;

namespace LocalMarketer.ApplicationServices.API.Handlers.ToDosHandlers
{
        public class GetAllToDosHandler : IRequestHandler<GetAllToDosRequest, GetAllToDosResponse>
        {
                private readonly IQueryExecutor executor;

                public GetAllToDosHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<GetAllToDosResponse> Handle(GetAllToDosRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllToDosQuery()
                        {
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        var DataFromDbMappedToModel = ToDosMapping.GetAllToDos(dataFromDb);

                        var response = new GetAllToDosResponse()
                        {
                                ResponseData = DataFromDbMappedToModel,
                        };
                        return response;
                }
        }
}
