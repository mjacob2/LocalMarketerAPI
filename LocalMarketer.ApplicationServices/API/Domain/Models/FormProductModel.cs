namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class FormProductModel
        {
                public string? ProfileName { get; set; }

                public List<ProductModel>? Products { get; set; }
        }

        public class ProductModel
        {
                public string Category { get; set; }
                public string Description { get; set; }
                public string Name { get; set; }
                public string Price { get; set; }
                public string Link { get; set; }
        }
}
