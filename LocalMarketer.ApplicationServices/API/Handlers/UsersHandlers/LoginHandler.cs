using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Queries.UserQueries;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.UsersHandlers
{
        public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
        {
                private readonly IQueryExecutor queryExecutor;
                private User dataFromDb;
                /// <summary>
                /// Initializes a new instance of the <see cref="LoginHandler"/> class.
                /// </summary>
                /// <param name="queryExecutor">The query executor.</param>
                public LoginHandler(IQueryExecutor queryExecutor)
                {
                        this.queryExecutor = queryExecutor;
                }

                /// <summary>
                /// Handles the.
                /// </summary>
                /// <param name="request">The request.</param>
                /// <param name="cancellationToken">The cancellation token.</param>
                /// <returns>A Task.</returns>
                public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetUserByEmailQuery()
                        {
                                Email = request.Email,
                        };

                        this.dataFromDb = await this.queryExecutor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new LoginResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotAuthenticated),
                                };
                        }

                        var passwordFromRequest = Hasher.HashPassword(request.Password, dataFromDb.Salt);

                        var passwordFromResponse = dataFromDb.Password;

                        if (passwordFromResponse != passwordFromRequest)
                        {
                                return new LoginResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotAuthenticated),
                                };
                        }

                        var dataFromDbMappedToModel = UsersMappings.GetUserModel(this.dataFromDb);

                        return new LoginResponse()
                        {
                                ResponseData = dataFromDbMappedToModel
                        };
                }
        }
}