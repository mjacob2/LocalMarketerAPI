using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.FormsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System.Globalization;

namespace LocalMarketer.ApplicationServices.API.Handlers.FormsHandlers
{
        public class GetFormBasicByIdHandler : IRequestHandler<GetFormBasicByIdRequest, GetFormBasicByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetFormBasicByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetFormBasicByIdResponse> Handle(GetFormBasicByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetFormBasicByIdQuery()
                        {
                                FormBasicId = request.FormBasicId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetFormBasicByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        var dataFromDbMappedToModel = FormBasicsMapping.GetFormBasicById(dataFromDb);

                        var response = new GetFormBasicByIdResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}