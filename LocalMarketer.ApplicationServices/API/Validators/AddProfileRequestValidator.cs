using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public class AddProfileRequestValidator : AbstractValidator<AddProfileRequest>
        {
                public AddProfileRequestValidator()
                {
                        this.RuleFor(x => x.Name)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Nazwa nie może być pusta")
                                .Length(1, 50)
                                .WithMessage("Nazwa nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.GoogleProfileId)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Identyfikator Gogole nie może być pusty")
                                .Length(1, 100)
                                .WithMessage("Identyfikator Gogole nie może być dłuższy niż 100 znaków");

                        this.RuleFor(x => x.Description)
                                .MaximumLength( 500)
                                .WithMessage("Opis nie może być dłuższy niż 500 znaków");
                }
        }
}
