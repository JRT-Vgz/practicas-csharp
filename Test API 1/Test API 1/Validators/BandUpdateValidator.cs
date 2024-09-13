using FluentValidation;
using Test_API_1.DTOs;

namespace Test_API_1.Validators
{
    public class BandUpdateValidator : AbstractValidator<BandUpdateDto>
    {
        public BandUpdateValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Los grupos sin nombre no podrán aparecer en el cartel del HellFest.");
        }
    }
}
