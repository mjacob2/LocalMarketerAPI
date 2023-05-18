using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class Package
        {
                [Key]
                public int PackageId { get; set; }

                [MaxLength(50)]
                public string Name { get; set; }
                public double MinimumPrice { get; set; }
                public int DurationInMonths { get; set; }


        }
}
