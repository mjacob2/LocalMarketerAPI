using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.ClientsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

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
                                Id = request.Id,
                                //LoggedUserRole = request.LoggedUserRole,
                                //LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetClientByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
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