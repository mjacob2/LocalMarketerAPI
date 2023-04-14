using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Queries.UserQueries;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Handlers.UsersHandlers
{
        public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
        {
                private readonly IQueryExecutor queryExecutor;

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

                        var userResponse = await this.queryExecutor.Execute(query);

                        if (userResponse == null)
                        {
                                return new LoginResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotAuthenticated),
                                };
                        }

                        var passwordFromRequest = Hasher.HashPassword(request.Password, userResponse.Salt);

                        var passwordFromResponse = userResponse.Password;

                        if (passwordFromResponse != passwordFromRequest)
                        {
                                return new LoginResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotAuthenticated),
                                };
                        }

                        return new LoginResponse()
                        {
                                ResponseData = new UserModel()
                                {
                                        Id = userResponse.Id,
                                        FirstName = userResponse.Firstname,
                                        LastName = userResponse.Lastname,
                                        Email = userResponse.Email,
                                        Phone = userResponse.Phone,
                                        Role = userResponse.Role,
                                },
                        };
                }
        }
}