using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.FormsQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.FormsHandlers
{
        internal class GetFormServiceByIdHandler : IRequestHandler<GetFormServiceByIdRequest, GetFormServiceByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetFormServiceByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetFormServiceByIdResponse> Handle(GetFormServiceByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetFormServiceByIdQuery()
                        {
                                FormServiceId = request.FormServiceId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetFormServiceByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        var dataFromDbMappedToModel = FormServicesMapping.GetFormServiceById(dataFromDb);

                        var response = new GetFormServiceByIdResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}