using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class UserModel
        {
                public int UserId { get; set; }
                public DateTime CreationDate { get; set; }
                public bool HasAccess { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
                public string Role { get; set; }
        }
}
