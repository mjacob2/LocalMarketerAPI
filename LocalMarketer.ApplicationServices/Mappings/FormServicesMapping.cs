using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.Mappings
{
        internal class FormServicesMapping
        {
                internal static FormServiceModel GetFormServiceById(FormService form)
                {
                        return new FormServiceModel()
                        {
                                ProfileName = form.Profile.Name,
                                Services = form.Services.Select(x => new ServiceModel()
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
