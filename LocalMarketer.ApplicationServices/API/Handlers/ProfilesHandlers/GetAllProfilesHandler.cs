using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System.Globalization;

namespace LocalMarketer.ApplicationServices.API.Handlers.ProfilesHandlers
{
        public class GetAllProfilesHandler : IRequestHandler<GetAllProfilesRequest, GetAllProfilesResponse>
        {
                private readonly IQueryExecutor executor;

                public GetAllProfilesHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetAllProfilesResponse> Handle(GetAllProfilesRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllProfilesQuery()
                        {
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);
                        var DataFromDbMappedToModel = ProfilesMappings.GetAllProfiles(dataFromDb);
                        var response = new GetAllProfilesResponse()
                        {
                                ResponseData = DataFromDbMappedToModel,
                        };
                        return response;
                }
        }
}
