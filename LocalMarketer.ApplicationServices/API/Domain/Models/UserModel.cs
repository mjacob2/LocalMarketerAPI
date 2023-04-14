using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class UserModel
        {
                public int Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
                public string Password { get; set; }
                public Roles Role { get; set; }

        }
}
