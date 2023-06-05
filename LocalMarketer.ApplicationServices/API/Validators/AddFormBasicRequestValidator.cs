using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public  class AddFormBasicRequestValidator : AbstractValidator<AddFormBasicRequest>
        {
                public AddFormBasicRequestValidator()
                {
                        this.RuleFor(x => x.DealId)
                                .GreaterThan(0)
                                .WithMessage("Wybrana umowa jest nieprawidłowa");

                        this.RuleFor(x => x.DealId)
                                .GreaterThan(0)
                                .WithMessage("Wybrana umowa jest nieprawidłowa");

                        this.RuleFor(x => x.OpenedDate)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Data Otwarcia nie może być pusta")
                                .Length(1, 50)
                                .WithMessage("Data Otwarcia nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.AcceptedPaymentMethods)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Metody płatności nie mogą być puste")
                                .Length(1, 200)
                                .WithMessage("Metody płatności nie mogą być dłuższe niż 200 znaków");

                        this.RuleFor(x => x.VisitsUrl)
                                .Cascade(CascadeMode.StopOnFirstFailure)
                                .MaximumLength(1000)
                                .WithMessage("Adres strony do umawiania wizyt nie może być dłuższy niż 1000 znaków")
                                    .Must(link =>
                                    {
                                            if (string.IsNullOrEmpty(link))
                                            {
                                                    return true; // Skip validation if the link is empty or null
                                            }

                                            return Uri.TryCreate(link, UriKind.Absolute, out _);
                                    })
                                    .WithMessage("Adres strony do umawiania wizyt musi być pełnym adresem. Najlepiej skopiuj adres z paska przeglądarki. Sprawdź, czy na początku jest https://");
                        
                        this.RuleFor(x => x.MondayFrom)
                                .MaximumLength(5)
                                .WithMessage("Poniedziałek od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.MondayTo)
                                .MaximumLength(5)
                                .WithMessage("Poniedziałek do - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.TuesdayFrom)
                                .MaximumLength(5)
                                .WithMessage("Wtorek od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.TuesdayTo)
                                .MaximumLength(5)
                                .WithMessage("Wtorek do - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.WednesdayFrom)
                                .MaximumLength(5)
                                .WithMessage("Środa od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.WednesdayTo)
                                .MaximumLength(5)
                                .WithMessage("Środa do - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.ThursdayFrom)
                                .MaximumLength(5)
                                .WithMessage("Czwartek od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.ThursdayTo)
                                .MaximumLength(5)
                                .WithMessage("Czwartek do - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.FridayFrom)
                                .MaximumLength(5)
                                .WithMessage("Piątek od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.FridayTo)
                                .MaximumLength(5)
                                .WithMessage("Piątek do - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.SaturdayFrom)
                                .MaximumLength(5)
                                .WithMessage("Sobota od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.SaturdayTo)
                                .MaximumLength(5)
                                .WithMessage("Sobota do - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.SundayFrom)
                                .MaximumLength(5)
                                .WithMessage("Niedziela od - nie może być dłuższe niż 5 znaków");

                        this.RuleFor(x => x.SundayTo)
                                .MaximumLength(5)
                                .WithMessage("Niedziela do - nie może być dłuższe niż 5 znaków");

                }
        }
}
