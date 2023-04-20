using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class Note : EntityBase
        {
                [Required]
                public int CreatorId { get; set; }

                [Required]
                [MaxLength(500)]
                public string Name { get; set; }

                public int ToDoId { get; set; }

                [JsonIgnore]
                public ToDo ToDo { get; set; }
                
        }
}
