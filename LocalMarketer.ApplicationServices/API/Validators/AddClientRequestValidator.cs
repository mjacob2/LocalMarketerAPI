﻿using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public class AddClientRequestValidator : AbstractValidator<AddClientRequest>
        {
                public AddClientRequestValidator()
                {
                        this.RuleFor(x => x.Name)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Nazwa Klienta nie może być pusta")
                                .Length(1, 50)
                                .WithMessage("Nazwa Klienta nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.FirstName)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Imię nie może być puste")
                                .Length(1, 100)
                                .WithMessage("Imię nie może być dłuższe niż 100 znaków");


                        this.RuleFor(x => x.LastName)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Nazwisko nie może być puste")
                                .Length(1, 100)
                                .WithMessage("Nazwisko nie może być dłuższe niż 100 znaków");

                        this.RuleFor(x => x.Phone)
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("Telefon nie może być pusty")
                                .Length(9, 9)
                                .WithMessage("Telefon musi zawierać 9 cyfr");

                        this.RuleFor(x => x.Email)
                                .EmailAddress()
                                .WithMessage("Podaj prawidłowy e-mail")
                                .Must(u => !string.IsNullOrWhiteSpace(u))
                                .WithMessage("E-mail nie może być pusty")
                                .Length(1, 50)
                                .WithMessage("E-mail nie może być dłuższy niż 50 znaków");

                        this.RuleFor(x => x.SellerId)
                                .GreaterThan(0)
                                .WithMessage("Należy wybrać sprzedawcę");

                        this.RuleFor(x => x.Description)
                                .MaximumLength(500)
                                .WithMessage("Opis nie może być dłuższy niż 500 znaków");
                }
        }
}
