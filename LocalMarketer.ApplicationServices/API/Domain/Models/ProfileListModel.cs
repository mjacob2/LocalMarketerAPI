using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ProfileListModel
        {
                public int Id { get; set; }
                public string GoogleProfileId { get; set; }
                public DateTime CreationDate { get; set; }
                public string Name { get; set; }
                public int CreatorId { get; set; }
                public int UserId { get; set; }
                public int ClientId { get; set; }
                public string Source { get; set; }
                public string City { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }



        }
}
