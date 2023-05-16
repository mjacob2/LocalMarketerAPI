using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class Attachment
        {
                public int AttachmentId { get; set; }
                public DateTime CreationDate { get; set; }

                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                public byte[] Data { get; set; }

                public int ProfileId { get; set; }

                [JsonIgnore]
                public Profile Profile { get; set; }
        }
}
