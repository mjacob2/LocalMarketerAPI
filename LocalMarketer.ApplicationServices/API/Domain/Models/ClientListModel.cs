namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ClientListModel
        {
                public int ClientId { get; set; }
                public DateTime CreationDate { get; set; }
                public string Name { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string Source { get; set; }
                public int CreatorId { get; set; }

                public string SellerFullName { get; set; }
                public string LocalMarketerFullName { get; set; }
        }
}
