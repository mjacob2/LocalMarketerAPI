using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class Deal : EntityBase
        {
                [Required]
                public int CreatorId { get; set; }

                public int ProfileId { get; set; }

                [JsonIgnore]
                public Profile Profile { get; set; }

                [Required]
                public DateTime EndDate { get; set; }

                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                [JsonIgnore]
                public Package Package { get; set; }
                public int PackageId { get; set; }

                public double Price { get; set; }

                [MaxLength(500)]
                public string Description { get; set; } = string.Empty;

                [Required]
                public string Stage { get; set; }

                public List<ToDo> ToDos { get; set; } = new List<ToDo> { };
        }
}
