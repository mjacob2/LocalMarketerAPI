using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Queries.ToDosQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocalMarketer.DataAccess.Entities.User;
using LocalMarketer.ApplicationServices.Mappings;

namespace LocalMarketer.ApplicationServices.API.Handlers.ToDosHandlers
{
        public class GetToDoByIdHandler : IRequestHandler<GetToDoByIdRequest, GetToDoByIdResponse>
        {
                private readonly IQueryExecutor executor;

                public GetToDoByIdHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetToDoByIdResponse> Handle(GetToDoByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetToDoByIdQuery()
                        {
                                ToDoId = request.ToDoId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetToDoByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        if (request.LoggedUserRole == Roles.Seller.ToString()
                                && dataFromDb.CreatorId.ToString() != request.LoggedUserId)
                        {
                                return new GetToDoByIdResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }

                        var dataFromDbMappedToModel = ToDosMapping.GetToDoById(dataFromDb);

                        var response = new GetToDoByIdResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}