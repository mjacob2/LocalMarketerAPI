using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Responses.UserResponses;
using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using LocalMarketer.DataAccess.CQRS.Commands.UsersCommands;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

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
                        if (request.Role == User.Roles.Administrator)
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
                                Firstname = request.Firstname,
                                Lastname = request.Lastname,
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
                                        Error = new ErrorModel(ErrorType.UsernameNotAvailable),
                                };
                        }

                        return new AddUserResponse()
                        {
                                ResponseData = new User()
                                {
                                        Id = this.dataFromDb.Id,
                                        AccesDenied = this.dataFromDb.AccesDenied,
                                        CreationDate = this.dataFromDb.CreationDate,
                                        Email = this.dataFromDb.Email,
                                        Firstname = this.dataFromDb.Firstname,
                                        Lastname = this.dataFromDb.Lastname,
                                        Phone = this.dataFromDb.Phone,
                                        Role = this.dataFromDb.Role,
                                        Salt = this.dataFromDb.Salt,
                                },
                        };

                }
        }
}