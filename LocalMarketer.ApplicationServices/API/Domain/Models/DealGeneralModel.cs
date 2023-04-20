using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocalMarketer.DataAccess.Entities.Deal;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class DealGeneralModel
        {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Stage { get; set; }
        }
}
