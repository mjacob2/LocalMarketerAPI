using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class Deal : EntityBase
        {
                [Required]
                public int CreatorId { get; set; }

                [Required]
                public int ProfileId { get; set; }

                public Profile Profile { get; set; }

                [Required]
                public DateTime EndDate { get; set; }

                [Required]
                [MaxLength(150)]
                public string Name { get; set; }

                public Package Package { get; set; }

                [Required]
                public int PackageId { get; set; }

                [Required]
                public double Price { get; set; }

                [MaxLength(500)]
                public string? Description { get; set; }

                [Required]
                public string Stage { get; set; }

                public List<ToDo> ToDos { get; set; } = new List<ToDo>();
        }
}
