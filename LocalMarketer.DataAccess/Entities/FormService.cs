using System;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class FormService
        {
                public int FormServiceId { get; set; }
                public int ProfileId { get; set; }

                [JsonIgnore]
                public Profile Profile { get; set; }

                public DateTime CreationDate { get; set; }

                public List<Service>? Services { get; set; }

        }
}
