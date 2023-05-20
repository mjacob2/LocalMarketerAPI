using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
