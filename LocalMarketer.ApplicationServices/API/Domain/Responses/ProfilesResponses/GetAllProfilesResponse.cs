using LocalMarketer.ApplicationServices.API.Domain.Models;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses
{
        public class GetAllProfilesResponse : ResponseBase<List<ProfileListModel>>
        {
                /// <summary>
                /// Gets or sets the count of all items in database.
                /// </summary>
                public int Count { get; set; }
        }
}