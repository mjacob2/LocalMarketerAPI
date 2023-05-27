using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.UsersQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System.Globalization;
using LocalMarketer.DataAccess.Entities;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

namespace LocalMarketer.ApplicationServices.API.Handlers.UsersHandlers
{
        public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
        {
                private readonly IQueryExecutor executor;

                public GetAllUsersHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllUsersQuery()
                        {
                                ShowOnlySellers = request.ShowOnlySellers,

                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);
                        var dataFromDbMappedToModel = UsersMappings.GetUserListModel(dataFromDb);
                        var response = new GetAllUsersResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };
                        return response;
                }
        }
}
