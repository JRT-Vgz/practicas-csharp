using FluentValidation;
using Test_API_1.DTOs;

namespace Test_API_1.Validators
{
    public class BandInsertValidator : AbstractValidator<BandInsertDto>
    {
        public BandInsertValidator() 
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Los grupos sin nombre no podrán aparecer en el cartel del HellFest.");
        }
    }
}
