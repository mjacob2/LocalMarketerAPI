using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public class UpdateProfileByIdRequestValidator : AbstractValidator<UpdateProfileByIdRequest>
        {
                public UpdateProfileByIdRequestValidator()
                {
                        this.RuleFor(x => x.ProfileId)
                                .GreaterThan(0)
                                .WithMessage("Wybrany profil jest nieprawidłowy");

                        this.RuleFor(x => x.ClientId)
                                .GreaterThan(0)
                                .WithMessage("Wybrany klient jest nieprawidłowy");

                        this.RuleFor(x => x.Name)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Nazwa nie może być pusta")
                                .Length(1, 50)
                                .WithMessage("Nazwa nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.Voivodeship)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Województwo nie może być puste")
                                .Length(1, 50)
                                .WithMessage("Województwo nie może być dłuższe niż 50 znaków");

                        this.RuleFor(x => x.City)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Miasto nie może być puste")
                                .Length(1, 50)
                                .WithMessage("Miasto nie może być dłuższe niż 50 znaków");

                        this.RuleFor(x => x.Street)
                                .MaximumLength(50)
                                .WithMessage("Ulica nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.PostCode)
                                .MaximumLength(50)
                                .WithMessage("Ulica nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.Phone)
                                .MaximumLength(9)
                                .WithMessage("Telefon nie może być dłuższy niż 9 znaków");

                        this.RuleFor(x => x.CustomerService)
                                .MaximumLength(50)
                                .WithMessage("Obsługa klienta nie może być dłuższy niż 50 znaków");

                        this.RuleFor(x => x.WebsiteUrl)
                                .MaximumLength(500)
                                .WithMessage("Adres www nie może być dłuższy niż 500 znaków");

                        this.RuleFor(x => x.GoogleProfileId)
                                .MaximumLength(100)
                                .WithMessage("Google ID nie może być dłuższy niż 100 znaków");

                        this.RuleFor(x => x.Description)
                                .MaximumLength(500)
                                .WithMessage("Opis nie może być dłuższy niż 500 znaków");

                        this.RuleFor(x => x.ProfileUrl)
                                .MaximumLength(500)
                                .WithMessage("Link do profilu w Google nie może być dłuższy niż 500 znaków");

                        this.RuleFor(x => x.MediaLink)
                                .MaximumLength(1500)
                                .WithMessage("Link do folderu z mediami nie może być dłuższy niż 1500 znaków");
                }
        }
}