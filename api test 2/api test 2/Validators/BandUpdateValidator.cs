using api_test_2.DTOs;
using FluentValidation;

namespace api_test_2.Validators
{
    public class BandUpdateValidator : AbstractValidator<BandUpdateDto>
    {
        public BandUpdateValidator() 
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("No estes vacio weylon.");
        }
    }
}
