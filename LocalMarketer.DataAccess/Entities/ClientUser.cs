using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class ClientUser
        {
                public int ClientId { get; set; }
                public int UserId { get; set; }
                public User? User { get; set; }
                public Client? Client { get; set; }
        }
}
