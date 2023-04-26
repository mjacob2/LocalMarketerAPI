using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.UsersQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        if (request.LoggedUserRole != User.Roles.Administrator.ToString())
                        {
                                return new GetAllUsersResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }

                        var query = new GetAllUsersQuery()
                        {
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);
                        var DataFromDbMappedToModel = UsersMappings.GetAllUsers(dataFromDb);
                        var response = new GetAllUsersResponse()
                        {
                                ResponseData = DataFromDbMappedToModel,
                        };
                        return response;
                }
        }
}
