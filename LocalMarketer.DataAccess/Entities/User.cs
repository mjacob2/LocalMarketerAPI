using System.ComponentModel.DataAnnotations;

namespace LocalMarketer.DataAccess.Entities
{
        public class User
        {
                public enum Roles
                {
                        Administrator = 0,
                        Manager = 1,
                        LocalMarketer = 2,
                        Seller = 3,
                }

                public int UserId { get; set; }

                public DateTime CreationDate { get; set; }

                [Required]
                [MaxLength(20)]
                public string FirstName { get; set; }

                [Required]
                [MaxLength(20)]
                public string LastName { get; set; }

                [Required]
                [MaxLength(50)]
                public string Email { get; set; }

                [Required]
                [MaxLength(15)]
                public string Phone { get; set; }

                [Required]
                [MaxLength(100)]
                public string Password { get; set; }

                [MaxLength(20)]
                public string Salt { get; set; }

                public string Role { get; set; }

                [Required]
                public bool AccesDenied { get; set; }

                public List<Client> Clients { get; set; } = new List<Client> { };
        }
}
