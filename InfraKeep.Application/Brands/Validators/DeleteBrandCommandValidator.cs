using FluentValidation;
using InfraKeep.Application.Brands.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraKeep.Application.Brands.Validators
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Некорректный ID для удаления");
        }
    }
}
