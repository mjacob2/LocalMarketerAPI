using LocalMarketer.ApplicationServices.API.Domain.Models;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses
{
        public class GetAllClientsResponse : ResponseBase<List<ClientListModel>>
        {
                /// <summary>
                /// Gets or sets the count of all items in database.
                /// </summary>
                public int Count { get; set;}
        }
}
