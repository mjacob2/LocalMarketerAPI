using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Handlers.ClientsHandlers;
using LocalMarketer.DataAccess.Entities;

namespace Tests.HandlersTests.ClientsHandlersTests
{
        public class GetClientByIdHandlerTest : TestsBase
        {
                [TestCase(1, "First Client")]
                [TestCase(2, "Second Client")]
                [TestCase(3, "Third Client")]
                public async Task GetClientByIdHandlerGetsProperClientFromDbForAdministrator(int clientId, string expectedClientName)
                {
                        // Arrange
                        var expected = new List<Client>(this.MemoryContext.Clients).Count;
                        var validRequest = new GetClientByIdRequest()
                        {
                                ClientId = clientId,
                                LoggedUserRole = "Administrator",
                                LoggedUserId = "1",
                        };
                        var handler = new GetClientByIdHandler(QueryExecutor);

                        // Act
                        var response = await handler.Handle(validRequest, default);

                        // Assert
                        var actualClientName = response.ResponseData.Name;

                        Assert.That(actualClientName, Is.EqualTo(expectedClientName));
                }

                [TestCase(1, "First Client")]
                [TestCase(2, "Second Client")]
                [TestCase(3, "Third Client")]
                public async Task GetClientByIdHandlerGetsProperClientFromDbForLocalMarketer(int clientId, string expectedClientName)
                {
                        // Arrange
                        var expected = new List<Client>(this.MemoryContext.Clients).Count;
                        var validRequest = new GetClientByIdRequest()
                        {
                                ClientId = clientId,
                                LoggedUserRole = "LocalMarketer",
                                LoggedUserId = "1",
                        };
                        var handler = new GetClientByIdHandler(QueryExecutor);

                        // Act
                        var response = await handler.Handle(validRequest, default);

                        // Assert
                        var actualClientName = response.ResponseData.Name;

                        Assert.That(actualClientName, Is.EqualTo(expectedClientName));
                }
        }
}
