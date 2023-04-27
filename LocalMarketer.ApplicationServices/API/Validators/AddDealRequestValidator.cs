using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
        public class AddDealRequestValidator : AbstractValidator<AddDealRequest>
        {
        public AddDealRequestValidator()
        {
                this.RuleFor(x => x.Name)
                        .Must(u => !string.IsNullOrWhiteSpace(u))
                        .WithMessage("Nazwa nie może być pusta")
                        .Length(1, 50)
                        .WithMessage("Nazwa nie może być dłuższa niż 50 znaków");

                this.RuleFor(x => x.Description)
                        .MaximumLength(500)
                        .WithMessage("Opis nie może być dłuższy niż 500 znaków");

                this.RuleFor(x => x.PackageId)
                        .GreaterThan(0)
                        .WithMessage("Nieprawidłowy pakiet");

                this.RuleFor(x => x.Price)
                    .GreaterThanOrEqualTo(x => x.selectedPackageMinPrice)
                    .WithMessage(x => $"Cena musi być wyższa niż minimalna cena pakietu: {x.selectedPackageMinPrice} PLN");

        }
}
