using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class FormProduct
        {
                public int FormProductId {get; set;}
                
                public int ProfileId {get; set;}

                [JsonIgnore]
                public Profile Profile { get; set; }

                public DateTime CreationDate { get; set; }

                public List<Product>? Products { get; set; }
        }
}
