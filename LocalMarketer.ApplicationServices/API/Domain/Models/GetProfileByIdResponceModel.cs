using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class GetProfileByIdResponceModel
        {
                public string Name { get; set; }
                public string GoogleProfileId { get; set; }
                public int CreatorId { get; set; }
                public int UserId { get; set; }
                public int ClientId { get; set; }
                public string Source { get; set; }
                public string WebsiteUrl { get; set; }
                public string ProfileUrl { get; set; }
                public string Description { get; set; }
                public string Voivodeship { get; set; }
                public string City { get; set; }
                public string Street { get; set; }
                public string PostCode { get; set; }
                public string Nip { get; set; }
                public string Regon { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string CustomerService { get; set; }
                public List<DealGeneral> Deals { get; set; }
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }
                public string ClientEmail { get; set; }

                public class ToDoGeneral
                {
                        public int Id { get; set; }
                        public bool isFinished { get; set; }
                        public string Title { get; set; }
                }

                public class DealGeneral
                {
                        public int Id { get; set; }
                        public string Name { get; set; }

                        public string Description { get; set; }

                        public List<ToDoGeneral> ToDos { get; set; }

                }
        }
}
