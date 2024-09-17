using FluentValidation;
using Test_api_3.DTOs;

namespace Test_api_3.Validators
{
    public class BandUpdateValidator : AbstractValidator<BandUpdateDto>
    {
        public BandUpdateValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("no wey");
        }
    }
}
