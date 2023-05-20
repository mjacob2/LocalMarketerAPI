using FluentValidation;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Validators
{
        internal class UpdateDealByIdRequestValdiator : AbstractValidator<UpdateDealByIdRequest>
        {
                public UpdateDealByIdRequestValdiator()
                {
                        this.RuleFor(x => x.Name)
                        .Must(u => !string.IsNullOrWhiteSpace(u))
                        .WithMessage("Nazwa nie może być pusta")
                        .Length(1, 50)
                        .WithMessage("Nazwa nie może być dłuższa niż 50 znaków");

                        this.RuleFor(x => x.Description)
                                .MaximumLength(500)
                                .WithMessage("Opis nie może być dłuższy niż 500 znaków");
                }
        }
}
