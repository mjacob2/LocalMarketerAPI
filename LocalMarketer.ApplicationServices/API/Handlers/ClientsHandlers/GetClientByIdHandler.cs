using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using System.Globalization;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers
{
        public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetClientByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetClientByIdQuery()
                        {
                                ClientId = request.ClientId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetClientByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        if (request.LoggedUserRole == Roles.Seller.ToString()
                                && dataFromDb.CreatorId.ToString() != request.LoggedUserId)
                        {
                                return new GetClientByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }

                        var DataFromDbMappedToModel = ClientsMapping.ClientDetailsProfile(dataFromDb);

                        var response = new GetClientByIdResponse()
                        {
                                ResponseData = DataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}