using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class FormFaqsMapping
        {
                internal static FormFaqModel GetFormFaqById(FormFaq form)
                {
                        return new FormFaqModel()
                        {
                                ProfileName = form.Profile.Name,

                                Question1 = form.Question1,
                                Question2 = form.Question2,
                                Question3 = form.Question3,
                                Question4 = form.Question4,
                                Question5 = form.Question5,
                                Question6 = form.Question6,

                                Answer1 = form.Answer1,
                                Answer2 = form.Answer2,
                                Answer3 = form.Answer3,
                                Answer4 = form.Answer4,
                                Answer5 = form.Answer5,
                                Answer6 = form.Answer6,
                        };
                }
        }
}
