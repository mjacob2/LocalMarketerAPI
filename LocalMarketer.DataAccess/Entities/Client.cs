using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace LocalMarketer.DataAccess.Entities
{
        public class Client : EntityBase
        {
                public List<User> Users { get; set; } = new List<User> { };

                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                [MaxLength(50)]
                public string? GoogleGroupId { get; set; }

                [Required]
                [MaxLength(100)]
                public string FirstName { get; set; }

                [Required]
                [MaxLength(100)]
                public string LastName { get; set; }

                [Required]
                [MaxLength(15)]
                public string Phone { get; set; }

                [Required]
                [MaxLength(50)]
                public string Email { get; set; }

                [MaxLength(500)]
                public string? Description { get; set; }

                [Required]
                public int CreatorId { get; set; }

                public string? CreatorFullName { get; set; }

                public List<Profile> Profiles { get; set; } = new List<Profile>{};

                public List<ClientUser> ClientUsers { get; set; } = new List<ClientUser> { };
    }
}
