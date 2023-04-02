using System.ComponentModel.DataAnnotations;

namespace LocalMarketer.DataAccess.Entities
{
        public class User : EntityBase
        {
                public enum Roles
                {
                        Manager,
                        LocalMarketer,
                        Seller
                }

                [Required]
                [MaxLength(20)]
                public string Firstname { get; set; }

                [Required]
                [MaxLength(20)]
                public string Lastname { get; set; }

                [Required]
                [MaxLength(50)]
                public string Email { get; set; }

                [Required]
                [MaxLength(15)]
                public string Phone { get; set; }

                [Required]
                [MaxLength(10)]
                public string Password { get; set; }

                [MaxLength(20)]
                public string Salt { get; set; }

                [Required]
                public Roles Role { get; set; }

                [Required]
                public bool AccesDenied { get; set; }

                public List<Profile> Profiles { get; set; }



        }
}
