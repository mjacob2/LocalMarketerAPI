using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class FormBasicsMapping
        {
                internal static FormBasicModel GetFormBasicById(FormBasic form)
                {
                        return new FormBasicModel()
                        {
                                ProfileId = form.ProfileId,
                                ProfileName = form.Profile.Name,
                                CreationDate = DateTime.Today,
                                AcceptedPaymentMethods = form.AcceptedPaymentMethods,
                                Atr1 = form.Atr1,
                                Atr10 = form.Atr10,
                                Atr11 = form.Atr11,
                                Atr12 = form.Atr12,
                                Atr13 = form.Atr13,
                                Atr14 = form.Atr14,
                                Atr15 = form.Atr15,
                                Atr16 = form.Atr16,
                                Atr17 = form.Atr17,
                                Atr2 = form.Atr2,
                                Atr3 = form.Atr3,
                                Atr4 = form.Atr4,
                                Atr5 = form.Atr5,
                                Atr6 = form.Atr6,
                                Atr7 = form.Atr7,
                                Atr8 = form.Atr8,
                                Atr9 = form.Atr9,
                                City = form.City,
                                CustomerService = form.CustomerService,
                                DealId = form.DealId,
                                Description = form.Description,
                                FridayFrom = form.FridayFrom,
                                FridayTo = form.FridayTo,
                                MondayFrom = form.MondayFrom,
                                MondayTo = form.MondayTo,
                                OpenedDate = form.OpenedDate,
                                Phone = form.Phone,
                                PostCode = form.PostCode,
                                SaturdayFrom = form.SaturdayFrom,
                                SaturdayTo = form.SaturdayTo,
                                Street = form.Street,
                                SundayFrom = form.SundayFrom,
                                SundayTo = form.SundayTo,
                                ThursdayFrom = form.ThursdayFrom,
                                ThursdayTo = form.ThursdayTo,
                                TuesdayFrom = form.TuesdayFrom,
                                VisitsUrl = form.VisitsUrl,
                                Voivodeship = form.Voivodeship,
                                WebsiteUrl = form.WebsiteUrl,
                                WednesdayFrom = form.WednesdayFrom,
                                WednesdayTo = form.WednesdayTo,
                        };
                }
        }
}
