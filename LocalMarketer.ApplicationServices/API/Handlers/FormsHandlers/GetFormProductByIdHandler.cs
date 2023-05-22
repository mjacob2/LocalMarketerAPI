using LocalMarketer.DataAccess.CQRS.Queries.FormsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System.Globalization;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationProducts.Mappings;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

namespace LocalMarketer.ApplicationProducts.API.Handlers.FormsHandlers
{
        public class GetFormProductByIdHandler : IRequestHandler<GetFormProductByIdRequest, GetFormProductByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetFormProductByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetFormProductByIdResponse> Handle(GetFormProductByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetFormProductByIdQuery()
                        {
                                FormProductId = request.FormProductId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetFormProductByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        var dataFromDbMappedToModel = FormProductsMapping.GetFormProductById(dataFromDb);

                        var response = new GetFormProductByIdResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}