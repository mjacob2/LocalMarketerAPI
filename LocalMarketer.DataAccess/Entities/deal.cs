using System.ComponentModel.DataAnnotations;

namespace LocalMarketer.DataAccess.Entities
{
        public class Deal : EntityBase
        {
                public enum Stages
                {
                        InProgress,
                        Finished,
                        Resignation
                }
                [Required]
                public int CreatorId { get; set; }

                public int ProfileId { get; set; }

                public Profile Profile { get; set; }

                [Required]
                public DateTime EndDate { get; set; }

                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                public double Price { get; set; }

                [MaxLength(500)]
                public string Description { get; set; } = string.Empty;

                [Required]
                public Stages Stage { get; set; }


        }
}
