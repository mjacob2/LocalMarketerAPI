using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class Service
        {
                public int ServiceId { get; set; }

                public DateTime CreationDate { get; set; }

                [MaxLength(150)]
                public string Category {get;  set; }

                [MaxLength(120)]
                public string Name { get; set; }

                public decimal Price { get; set; }

                [MaxLength(300)]
                public string Description { get; set; }

                public int FormServiceId { get; set; }

                [JsonIgnore]
                public FormService FormService { get; set; }

        }
}
