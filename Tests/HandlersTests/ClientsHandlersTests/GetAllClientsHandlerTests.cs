using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;

namespace Tests.HandlersTests.ClientsHandlersTests
{
        public class GetAllClientsHandlerTests : TestsBase
        {
                [Test]
                public async Task AdministratorGetsListOfAllClients()
                {
                        // Arrange
                        var expected = new List<Client>(this.MemoryContext.Clients).Count;
                        var validRequest = new GetAllClientsRequest()
                        {
                                LoggedUserRole = "Administrator",
                                LoggedUserId = "0",
                        };
                        var executor = new QueryExecutor(this.MemoryContext);
                        var handler = new GetAllClientsHandler(executor);

                        // Act
                        var response = await handler.Handle(validRequest, default);

                        // Assert
                        var actual = response.ResponseData.Count;

                        Assert.That(actual, Is.EqualTo(expected));
                }

                [TestCase(4)]
                [TestCase(5)]
                public async Task LocalMarketerGetsListOfAllClients(int LocalMarketerId)
                {
                        // Arrange
                        var expected = new List<Client>(this.MemoryContext.Clients).Count;
                        var validRequest = new GetAllClientsRequest()
                        {
                                LoggedUserRole = "LocalMarketer",
                                LoggedUserId = LocalMarketerId.ToString(),
                        };
                        var executor = new QueryExecutor(this.MemoryContext);
                        var handler = new GetAllClientsHandler(executor);

                        // Act
                        var response = await handler.Handle(validRequest, default);

                        // Assert
                        var actual = response.ResponseData.Count;

                        Assert.That(actual, Is.EqualTo(expected));
                }

                [TestCase(2)]
                [TestCase(3)]
                public async Task SellerIdGetsOnlyClientsThatHeCreated(int creatorId)
                {
                        // Arrange
                        var validRequest = new GetAllClientsRequest()
                        {
                                LoggedUserRole = "Seller",
                                LoggedUserId = creatorId.ToString(),
                        };
                        var executor = new QueryExecutor(this.MemoryContext);
                        var handler = new GetAllClientsHandler(executor);

                        // Act
                        var response = await handler.Handle(validRequest, default);

                        // Assert
                        var actual = response.ResponseData;


                        Assert.IsTrue(actual.All(x => x.CreatorId == creatorId));
                }
        }
}
