using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class FormFaqsMapping
        {
                internal static FormFaqModel GetFormFaqById(FormFaq data)
                {
                        return new FormFaqModel()
                        {
                                ProfileName = data.Profile.Name,

                                Question1 = data.Question1,
                                Question2 = data.Question2,
                                Question3 = data.Question3,
                                Question4 = data.Question4,
                                Question5 = data.Question5,
                                Question6 = data.Question6,

                                Answer1 = data.Answer1,
                                Answer2 = data.Answer2,
                                Answer3 = data.Answer3,
                                Answer4 = data.Answer4,
                                Answer5 = data.Answer5,
                                Answer6 = data.Answer6,
                        };
                }
        }
}
