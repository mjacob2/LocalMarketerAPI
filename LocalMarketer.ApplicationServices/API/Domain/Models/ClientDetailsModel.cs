using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ClientDetailsModel
        {
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }
                public int? UserId { get; set; }
                public string Name { get; set; }
                public string GoogleGroupId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string Voivodeship { get; set; }
                public string City { get; set; }
                public string Street { get; set; }
                public string PostCode { get; set; }
                public string Source { get; set; }
                public string Description { get; set; }
                public int SellerId { get; set; }
                public List<ProfileGeneralModel> Profiles { get; set; }
                public List<DealGeneralModel> Deals { get; set; }

                public List<UserListModel> Users { get; set; }
        }
}
