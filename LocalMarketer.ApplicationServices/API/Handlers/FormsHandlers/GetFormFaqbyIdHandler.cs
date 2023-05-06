using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocalMarketer.DataAccess.Entities.User;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.DataAccess.CQRS.Queries.FormsQueries;

namespace LocalMarketer.ApplicationServices.API.Handlers.FormsHandlers
{
        public class GetFormFaqbyIdHandler : IRequestHandler<GetFormFaqByIdRequest, GetFormFaqByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetFormFaqbyIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetFormFaqByIdResponse> Handle(GetFormFaqByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetFormFaqByIdQuery()
                        {
                                FormFaqId = request.FormFaqId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetFormFaqByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        var dataFromDbMappedToModel = FormFaqsMapping.GetFormFaqById(dataFromDb);

                        var response = new GetFormFaqByIdResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}