using FluentValidation;
using InfraKeep.Application.Brands.Commands;

namespace InfraKeep.Application.Brands.Validators
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x => x.Brand.Id)
                .GreaterThan(0)
                .WithMessage("Id должен быть больше 0");

            RuleFor(x => x.Brand.Name)
                .NotEmpty().WithMessage("Название обязательно")
                .MaximumLength(100).WithMessage("Максимальная длина 100 символов");
        }
    }
}
