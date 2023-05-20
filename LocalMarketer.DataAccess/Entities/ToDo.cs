using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class ToDo
        {
                public int ToDoId { get; set; }

                public DateTime CreationDate { get; set; }
                public int CreatorId { get; set; }

                [Required]
                [MaxLength(250)]
                public string Title { get; set; }

                public int DealId { get; set; }

                [JsonIgnore]
                public Deal Deal { get; set; }

                [Required]
                public DateTime DueDate { get; set; }

                [MaxLength(500)]
                public string Description { get; set; }

                [Required]
                public bool IsFinished { get; set; }

                public List<Note>? Notes { get; set; }
                public string? Link1 { get; set; }
                public string? Link2 { get; set; }
                public string? Link3 { get; set; }
                public string? Link4 { get; set; }
                public string? Link5 { get; set; }

                [Required]
                [MaxLength(20)]
                public string ForRole { get; set; }
        }
}
