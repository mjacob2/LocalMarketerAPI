using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
