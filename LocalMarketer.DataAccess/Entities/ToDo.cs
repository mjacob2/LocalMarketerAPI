using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class ToDo : EntityBase
        {
                public int CreatorId { get; set; }

                [Required]
                [MaxLength(50)]
                public string Title { get; set; }

                public int DealId { get; set; }

                [JsonIgnore]
                public Deal Deal { get; set; }

                [Required]
                public DateTime StartDate { get; set; }

                [Required]
                public DateTime DueDate { get; set; }

                [MaxLength(500)]
                public string Description { get; set; } = string.Empty;

                [Required]
                public bool IsFinished { get; set; }

                public List<Note>? Notes { get; set; }=  new List<Note> { };

        }
}
