using FluentValidation;
using Test_api_3.DTOs;

namespace Test_api_3.Validators
{
    public class BandInsertValidator : AbstractValidator<BandInsertDto>
    {
        public BandInsertValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("no weylon");
        }
    }
}
