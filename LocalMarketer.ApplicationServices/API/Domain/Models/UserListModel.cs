using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class UserListModel
        {
                public int? UserId { get; set; }
                public DateTime? CreationDate { get; set; }
                public string? FirstName { get; set; }
                public string? LastName { get; set; }
                public string? Phone { get; set; }
                public string? Email { get; set; }
                public string? Role { get; set; }
                public bool? HasAccess { get; set; }
                public int? ProfilesCount { get; set; }
                public int? ToDosCount { get; set; }
        }
}
