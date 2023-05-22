using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        public class AddFormProductRequestValidator : AbstractValidator<AddFormProductRequest>
        {
        public AddFormProductRequestValidator()
                {
                        RuleFor(request => request.Products)
                            .NotNull().WithMessage("Products list is required.")
                            .ForEach(productRule => productRule.SetValidator(new ProductValidator()));
                }
        }

        public class ProductValidator : AbstractValidator<Product>
        {
                public ProductValidator()
                {
                        RuleFor(product => product.Category)
                            .Must(u => !string.IsNullOrWhiteSpace(u))
                            .WithMessage("Kategoria jest wymagana w kazdym produkcie")
                            .MaximumLength(150).WithMessage("Kategoria nie może byc dłuższa niż 150 znaków");

                        RuleFor(product => product.Image)
                            .Must(u => !string.IsNullOrWhiteSpace(u))
                            .WithMessage("Zdjęcie jest wymagane w każdym produkcie");

                        RuleFor(product => product.Name)
                            .Must(u => !string.IsNullOrWhiteSpace(u))
                            .WithMessage("Nazwa jest wymagana w każdym produkcie")
                            .MaximumLength(58).WithMessage("Nazwa nie może byc dłuższa niż 150 znaków");

                        RuleFor(product => product.Description)
                            .MaximumLength(1000).WithMessage("Opis nie może byc dłuższy niż 1000 znaków");

                        RuleFor(product => product.Price)
                            .MaximumLength(100).WithMessage("Cena nie może byc dłuższa niż 100 znaków");

                        RuleFor(product => product.Link)
                            .MaximumLength(1500).WithMessage("Link nie może przekraczać 1500 znaków");


                }
        }


}
