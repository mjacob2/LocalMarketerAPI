using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class Client : EntityBase
        {
                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                [MaxLength(50)]
                public string? GoogleGroupId { get; set; } = string.Empty;

                [Required]
                [MaxLength(20)]
                public string FirstName { get; set; }

                [Required]
                [MaxLength(20)]
                public string LastName { get; set; }

                [Required]
                [MaxLength(15)]
                public string Phone { get; set; }

                [Required]
                [MaxLength(50)]
                public string Email { get; set; }

                [MaxLength(50)]
                public string Source { get; set; } = string.Empty;

                [MaxLength(500)]
                public string Description { get; set; } = string.Empty;

                [Required]
                public int CreatorId { get; set; }

                public List<Profile> Profiles { get; set; } = new List<Profile>{};
}
}
