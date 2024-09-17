using api_test_2.DTOs;
using FluentValidation;

namespace api_test_2.Validators
{
    public class BandInsertValidator : AbstractValidator<BandInsertDto>
    {
        public BandInsertValidator() 
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("No estes bacio por dentro wey.");
        }
    }
}
