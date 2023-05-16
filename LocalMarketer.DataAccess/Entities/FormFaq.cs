using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class FormFaq
        {
                public int FormFaqId { get; set; }

                public DateTime CreationDate { get; set; }
                public int ProfileId { get; set; }

                [JsonIgnore]
                public Profile Profile { get; set; }

                public string? Question1 { get; set; }
                public string? Answer1 { get; set; }

                public string? Question2 { get; set; }
                public string? Answer2 { get; set; }

                public string? Question3 { get; set; }
                public string? Answer3 { get; set; }

                public string? Question4 { get; set; }
                public string? Answer4 { get; set; }

                public string? Question5 { get; set; }
                public string? Answer5 { get; set; }

                public string? Question6 { get; set; }
                public string? Answer6 { get; set; }
        }
}
