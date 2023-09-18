using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class Profile : EntityBase
        {
                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                [MaxLength(100)]
                public string? GoogleProfileId { get; set; }

                [Required]
                public int CreatorId { get; set; }

                public int ClientId { get; set; }

                public Client Client { get; set; }

                [MaxLength(500)]
                public string? WebsiteUrl { get; set; }

                [MaxLength(500)]
                public string? ProfileUrl { get; set; }

                [MaxLength(500)]
                public string? Description { get; set; }

                [MaxLength(50)]
                public string? Voivodeship { get; set; }

                [MaxLength(50)]
                public string? City { get; set; }

                [MaxLength(50)]
                public string? Street { get; set; }

                [MaxLength(10)]
                public string? PostCode { get; set; }

                [MaxLength(15)]
                public string? Phone { get; set; }

                [MaxLength(1500)]
                public string? MediaLink { get; set; }

                [MaxLength(50)]
                public string? CustomerService { get; set; }

                public List<Deal> Deals { get; set; } = new List<Deal>();

                public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        }
}
