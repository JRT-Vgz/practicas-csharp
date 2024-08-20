using Demo_REST_API.DTOs;
using FluentValidation;

namespace Demo_REST_API.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator() 
        {
            RuleFor(x =>  x.Name).NotEmpty();
        }
    }
}
