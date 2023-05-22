using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.FormsCommands;

namespace LocalMarketer.ApplicationProducts.API.Handlers.FormsHandlers
{
        public class AddFormProductHandler : IRequestHandler<AddFormProductRequest, AddFormProductResponse>
        {
                private readonly ICommandExecutor executor;
                private FormProduct dataFromDb;

                public AddFormProductHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddFormProductResponse> Handle(AddFormProductRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new FormProduct()
                        {
                                CreationDate = DateTime.Today,
                                ProfileId = request.ProfileId,
                                Products = new List<DataAccess.Entities.Product>(),
                        };

                        if (request.Products != null)
                        {
                                foreach (var Product in request.Products)
                                {
                                        var ProductToAdd = new DataAccess.Entities.Product
                                        {
                                                Category = Product.Category,
                                                Description = Product.Description,
                                                Name = Product.Name,
                                                Price = Product.Price,
                                                Link = Product.Link,
                                                //ImagePath = Product.ImagePath,

                                        };

                                        itemtoAdd.Products.Add(ProductToAdd);
                                }
                        }


                        var command = new AddFormProductCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);

                                await CreateAutomaticToDos(request.DealId, this.dataFromDb.FormProductId);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddFormProductResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }


                        var response = new AddFormProductResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }

                private async Task CreateAutomaticToDos(int dealId, int formProductId)
                {
                        var threeDaysFromNow = DateTime.Today.AddDays(3);

                        var todo = new ToDo()
                        {
                                DealId = dealId,
                                CreationDate = DateTime.Today,
                                CreatorId = 0,
                                Title = "Uzupełnij PRODUKTY z formularza klienta",
                                DueDate = threeDaysFromNow,
                                Description = "",
                                IsFinished = false,
                                Notes = new List<Note>(),
                                Link1 = $"http://localhost:4200/formProduct/{formProductId}",
                                ForRole = User.Roles.LocalMarketer.ToString(),
                        };


                        var command = new AddToDoCommand() { Parameter = todo };
                        try
                        {
                                await this.executor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                        {
                                throw new InvalidOperationException(ex.Message);
                        }

                }
        }
}