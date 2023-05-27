using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using Org.BouncyCastle.Math.EC.Rfc7748;

public class AddDealRequestValidator : AbstractValidator<AddDealRequest>
{
        public AddDealRequestValidator()
        {
                this.RuleFor(x => x.ProfileId)
                        .GreaterThan(0)
                        .WithMessage(errorMessage: "Należy przypisać profil");

                this.RuleFor(x => x.Name)
                        .Must(u => !string.IsNullOrWhiteSpace(u))
                        .WithMessage("Nazwa nie może być pusta")
                        .Length(1, 150)
                        .WithMessage("Nazwa nie może być dłuższa niż 150 znaków");

                this.RuleFor(x => x.SelectedPackage)
                        .NotNull()
                        .WithMessage("Należy wybrać pakiet");

                this.RuleFor(x => x.Price)
                        .Must((model, price) => model.SelectedPackage == null || price >= model.SelectedPackage.MinimumPrice)
                        .WithMessage(x => $"Cena musi być wyższa niż minimalna cena pakietu: {(x.SelectedPackage != null ? x.SelectedPackage.MinimumPrice.ToString() : "N/A")} PLN");

                this.RuleFor(x => x.ProfileName)
                        .Must(u => !string.IsNullOrWhiteSpace(u))
                        .WithMessage("Nazwa profilu nie może być pusta");

                this.RuleFor(x => x.ClientEmail)
                        .Must(u => !string.IsNullOrWhiteSpace(u))
                        .WithMessage("E-mail klienta nie może być pusty");

                this.RuleFor(x => x.Description)
                        .MaximumLength(500)
                        .WithMessage("Opis nie może być dłuższy niż 500 znaków");
        }
}
