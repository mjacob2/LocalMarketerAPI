﻿namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class DealListModel
        {
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }
                public string Name { get; set; }
                public DateTime EndDate { get; set; }
                public string Stage { get; set; }
                public int CreatorId { get; set; }
        }
}
