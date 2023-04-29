using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System.Globalization;
using static LocalMarketer.DataAccess.Entities.User;
using LocalMarketer.ApplicationServices.Mappings;

namespace LocalMarketer.ApplicationServices.API.Handlers.ProfilesHandlers
{
        public class GetProfileByIdHandler : IRequestHandler<GetProfileByIdRequest, GetProfileByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetProfileByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetProfileByIdResponse> Handle(GetProfileByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetProfileByIdQuery()
                        {
                                ProfileId = request.ProfileId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetProfileByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        if (request.LoggedUserRole == Roles.Seller.ToString()
                                && dataFromDb.CreatorId.ToString() != request.LoggedUserId)
                        {
                                return new GetProfileByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }

                        var dataFromDbMappedToModel = ProfilesMappings.GetProfileById(dataFromDb);

                        var response = new GetProfileByIdResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}