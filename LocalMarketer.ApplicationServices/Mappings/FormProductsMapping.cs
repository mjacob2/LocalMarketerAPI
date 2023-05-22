using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationProducts.Mappings
{
        internal class FormProductsMapping
        {
                internal static FormProductModel GetFormProductById(FormProduct form)
                {
                        return new FormProductModel()
                        {
                                ProfileName = form.Profile.Name,
                                Products = form.Products.Select(x => new ProductModel()
                                {
                                        Category = x.Category,
                                        Description = x.Description,
                                        Name = x.Name,
                                        Price = x.Price,
                                }).ToList(),
                        };
                }
        }
}
