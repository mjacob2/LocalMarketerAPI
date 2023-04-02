using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class Activity : EntityBase
        {
                public enum Statuses
                {
                        NotStarted,
                        InProgress,
                        Done
                }

                [Required]
                [MaxLength(50)]
                public string Title { get; set; }

                public int ProfileId { get; set; }

                public Profile Profile { get; set; }

                [Required]
                public DateTime StartDate { get; set; }

                [Required]
                public DateTime DueDate { get; set; }

                [MaxLength(500)]
                public string Description { get; set; } = string.Empty;

                [Required]
                public Statuses Status { get; set; }

                [MaxLength(100)]
                public string Note1 { get; set; } = string.Empty;

                [MaxLength(100)]
                public string Note2 { get; set; } = string.Empty;

                [MaxLength(100)]
                public string Note3 { get; set; } = string.Empty;

                [MaxLength(100)]
                public string Note4 { get; set; } = string.Empty;

                [MaxLength(100)]
                public string Note5 { get; set; } = string.Empty;





        }
}
