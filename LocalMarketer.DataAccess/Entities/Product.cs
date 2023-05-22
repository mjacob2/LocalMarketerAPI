using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class Product
        {
                public int ProductId {get;  set;}
                public DateTime CrteationDate {get; set;}

                [MaxLength(150)]
                public string Category { get; set; }

                [MaxLength(58)]
                public string Name { get; set; }

                [MaxLength(1000)]
                public string? Description { get; set; }

                [MaxLength(100)]
                public string? Price { get; set; }

                [MaxLength(1500)]
                public string? Link { get; set; }

                [MaxLength(150)]
                public string ImageName { get; set; }

                public int FormProductId { get; set; }

                [JsonIgnore]
                public FormProduct FormProduct { get; set; }
        }
}
