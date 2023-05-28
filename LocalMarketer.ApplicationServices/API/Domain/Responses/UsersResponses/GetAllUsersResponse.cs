using LocalMarketer.ApplicationServices.API.Domain.Models;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses
{
        public class GetAllUsersResponse : ResponseBase<List<UserListModel>>
        {
                /// <summary>
                /// Gets or sets the count of all items in database.
                /// </summary>
                public int Count { get; set; }
        }
}