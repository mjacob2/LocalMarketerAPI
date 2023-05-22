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

                [MaxLength(120)]
                public string Name { get; set; }

                [MaxLength(300)]
                public string Description { get; set; }

                [MaxLength(50)]
                public string Price { get; set; }

                [MaxLength(250)]
                public string Link { get; set; }

                public string? ImagePath { get; set; }

                public int FormProductId { get; set; }

                [JsonIgnore]
                public FormProduct FormProduct { get; set; }
        }
}
