using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public class AddToDoRequestValidator : AbstractValidator<AddToDoRequest>
        {
                public AddToDoRequestValidator()
                {
                        this.RuleFor(x => x.Title)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Tytuł nie może być pusty")
                                .Length(1, 50)
                                .WithMessage("Tytuł nie może być dłuższy niż 50 znaków");
                        this.RuleFor(x => x.Description)
                                .MaximumLength(500)
                                .WithMessage("Opis nie może być dłuższy niż 500 znaków");
                        this.RuleFor(x => x.DueDate)
                                .GreaterThanOrEqualTo(x => x.DealCreationDate)
                                .WithMessage("Termin nie może być wczesniejszy niż data początku umowy")
                                .LessThan(x => x.DealEndDate)
                                .WithMessage("Termin nie może być póżniej niż data końca umowy");

                }
        }
}
