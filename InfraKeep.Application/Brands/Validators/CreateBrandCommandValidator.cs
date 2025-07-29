using FluentValidation;
using InfraKeep.Application.Brands.Commands;

namespace InfraKeep.Application.Brands.Validators
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Brand.Name)
                .NotEmpty().WithMessage("Название обязательно!")
                .MaximumLength(100);
        }
    }
}
