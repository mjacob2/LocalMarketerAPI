using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
        {
                public AddUserRequestValidator()
                {
                        this.RuleFor(x => x.Firstname)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Imię nie może być puste")
                                .Length(1, 20)
                                .WithMessage("Imię nie może być dłuższe niż 20 znaków");

                        this.RuleFor(x => x.Lastname)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Nazwisko nie może być puste")
                                .Length(1, 20)
                                .WithMessage("Nazwisko nie może być dłuższe niż 20 znaków");

                        this.RuleFor(x => x.Email)
                                .EmailAddress()
                                .WithMessage("Podaj prawidłowy e-mail")
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("E-mail nie może być pusty")
                                .Length(1, 50)
                                .WithMessage("e-mail nie może być dłuższy niż 50 znaków");

                        this.RuleFor(x => x.Phone)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Telefon nie może być pusty")
                                .Length(9, 9)
                                .WithMessage("Telefon musi zawierać 9 cyfr");

                        this.RuleFor(x => x.Password)
                                .MinimumLength(8)
                                .WithMessage("Hasło musi mieć przynajmniej 8 znaków")
                                .MaximumLength(100)
                                .WithMessage("Hasło nie może być dłuższe niż 100 znaków")
                                .Matches(@"[A-Z]+")
                                .WithMessage("Hasło musi zawierać przynajmniej jedną wielką literę")
                                .Matches(@"[a-z]+")
                                .WithMessage("Hasło musi zawierać przynajmniej jedną małą literę")
                                .Matches(@"[0-9]+")
                                .WithMessage("Hasło musi zawierać przynajmniej jedną cyfrę")
                                .Matches(@"[\!\@\#\$\%\^\&\*\(\)\{\}\[\]\:\;\'\,\.\?\+\=\-\\_]+")
                                .WithMessage("Hasło musi zawierać przynajmniej jeden znak specjalny");

                        this.RuleFor(x => x.Role)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("rola nie może być pusta")
                                .Matches(@"[\\Administrator\\Seller\\LocalMarketer\\Manager]+")
                                .WithMessage("Rola nieprawidłowa");


                }

        }
}