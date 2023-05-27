using LocalMarketer.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ClientModel
        {
                public int? ClientId {get;  set;}
                public DateTime? CreationDate {get; set;}
                public string? Name { get; set; }
                public string? GoogleGroupId { get; set; }
                public string? FirstName { get; set; }
                public string? LastName { get; set; }
                public string? Phone { get; set; }
                public string? Email { get; set; }
                public string? Description { get; set; }
                public int? CreatorId { get; set; }
        }
}
