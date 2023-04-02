using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ClientListModel
        {
                public int Id { get; set; }

                public string FirstName { get; set; }

                public string LastName { get; set; }

                public string Phone { get; set; }

                public string Email { get; set; }

                public string Source { get; set; }
                public string SellerEmail { get; set; }

        }
}
