using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class DealDetailsModel
        {
                public int? ProfileUserId { get; set; }
                public DateTime CreationDate { get; set; }
                public int Id { get; set; }
                public int CreatorId { get; set; }
                public int ProfileId { get; set; }
                public string Name { get; set; }
                public int PackageId { get; set; }
                public double Price { get; set; }
                public string Description { get; set; }
                public string Stage { get; set; }

                public DateTime EndDate { get; set; }
                public List<ToDoModel> ToDos { get; set; }

                public string SellerFullName { get; set; }

        }
}
