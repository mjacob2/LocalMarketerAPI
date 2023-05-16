using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.DataAccess.CQRS.Commands.UsersCommands;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;

namespace LocalMarketer.ApplicationServices.API.Handlers.UsersHandlers
{
        public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
        {
                private readonly ICommandExecutor executor;
                private User dataFromDb;

                public AddUserHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
                {
                        if (request.LoggedUserRole != User.Roles.Administrator.ToString())
                        {
                                return new AddUserResponse()
                                {
                                        Error = new ErrorModel(ErrorType.Unauthorized),
                                };
                        }

                        if (request.Role == User.Roles.Administrator.ToString())
                        {
                                return new AddUserResponse()
                                {
                                        Error = new ErrorModel(ErrorType.AdministratorRoleNoMore)
                                };
                        }
                        var salt = Hasher.GetSalt();
                        var passwordHashed = Hasher.HashPassword(request.Password, salt);

                        var itemtoAdd = new User()
                        {
                                CreationDate = DateTime.Today,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                Email = request.Email,
                                Phone = request.Phone,
                                AccesDenied = false,
                                Role = request.Role,
                                Password = passwordHashed,
                                Salt = salt,
                        };

                        var command = new AddUserCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);
                                
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddUserResponse()
                                {
                                        Error = new ErrorModel(ErrorType.UserAlreadyExists),
                                };
                        }

                        return new AddUserResponse()
                        {
                                ResponseData = new User()
                                {
                                        UserId = this.dataFromDb.UserId,
                                        AccesDenied = this.dataFromDb.AccesDenied,
                                        CreationDate = this.dataFromDb.CreationDate,
                                        Email = this.dataFromDb.Email,
                                        FirstName = this.dataFromDb.FirstName,
                                        LastName = this.dataFromDb.LastName,
                                        Phone = this.dataFromDb.Phone,
                                        Role = this.dataFromDb.Role,
                                        Salt = this.dataFromDb.Salt,
                                },
                        };

                }
        }
}